PRO ZHEJIANG_SST_FROM_GLOBAL_NC, path_input, path_output

  ;实现全球4km的nc海温数据的浙江海区的切割
  ;并将像元的经纬度信息作为变量包含进去
  ;创建日期：2017-10-14
  ;修订日期：2017-10-14
  DEVICE,get_decomposed=odbc
  TVLCT,red,green,blue,/get

  DEVICE,decomposed=0
  LOADCT,13
  ;  file='E:\A20092442009273.L3m_MO_SST_4'

  MyRootDir=path_input
  files = FILE_SEARCH(MyRootDir+'\*.nc',count=num);

  step=0.0416667d

  sample=160   ;定义浙江海域大小
  line=175

  UL_SAMPLE=6843 ;取得(中国海域)图像左上点列号
  UL_LIEN=1172  ;取得(中国海域)图像左上点行号


  U_lat= 89.979164-STEP*(UL_LIEN+201)  ;定义剪裁后（浙江海域）图像的最上纬度
  L_lon= -179.97917+step*(UL_SAMPLE+316);定义剪裁后（浙江海域）图像的最左经度

  ;****首先要了解MODIS 4km产品的网格特点，其全球产品大小为 [8640, 4320]
  ;    网格点经纬度步长为0.0416667，左下角点的经度为-180加上半个步长大小（即 -179.97917）
  ;    左下角纬度为90减去个步长大小   （即 89.979164）  注：图像倒置的
  ;


  lat=FLTARR(sample,line)    ;529------------->648,增119像元
  lon=FLTARR(sample,line)

  FOR j=0L,line-1 DO lat[0,j]=U_lat-j*step
  FOR j=0L,sample-1 DO lat[j,*]=lat[0,*]
  ; tvscl,lat

  FOR i=0L,sample-1 DO lon[i,0]=L_lon+i*step
  FOR i=0L,line-1 DO lon[*,i]=lon[*,0]
  ;  tvscl,lon


  IF num GT 0 THEN BEGIN   ;计算平均值
    PRINT,'the number of SST files is',num
    PRINT,files
    FOR i=0,num-1 DO BEGIN

      nid = NCDF_OPEN(files[i], /nowrite )
      sstid = NCDF_VARID(nid, 'sst')
      NCDF_ATTGET,nid,sstid,'scale_factor',scale_factor   ;或者变量sst里名为scale_factor的属性，存放如scale_factor中
      NCDF_ATTGET,nid,sstid,'add_offset',add_offset   ;或者变量sst里名为add_offset的属性，存放如add_offset中

      ; NCDF_VARGET, nid, latitude_id,latitude

      NCDF_VARGET, nid, sstid, sst
      sst=sst[UL_SAMPLE+316:UL_SAMPLE+316+sample-1,UL_LIEN+201:UL_LIEN+201+line-1]
      sst=sst*scale_factor+add_offset

      NCDF_CLOSE,nid

      PRINT,i

      PRINT,MAX(sst)
      ;      dis=where((sst ge -5.0) and (sst lt 40.0))
      ;      print,min(sst)


      fn=FILE_BASENAME(files[i],'.nc')
      fp=path_output
      fn_new=fp+'\'+fn+'_Zhejiang.hdf'

      hdfid2=HDF_SD_START(fn_new,/creat)
      varid=HDF_SD_CREATE(hdfid2,'SST',[sample,line],/float)
      varid1=HDF_SD_CREATE(hdfid2,'Latitude',[sample,line],/float)
      varid2=HDF_SD_CREATE(hdfid2,'Longitude',[sample,line],/float)
      HDF_SD_ADDDATA,varid,sst
      HDF_SD_ADDDATA,varid1,lat
      HDF_SD_ADDDATA,varid2,lon
      HDF_SD_ENDACCESS,varid
      HDF_SD_ENDACCESS,varid1
      HDF_SD_ENDACCESS,varid2
      HDF_SD_END,hdfid2

    ENDFOR
  ENDIF


END