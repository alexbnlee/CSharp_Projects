PRO CHINA_SST_FROM_GLOBAL_NC, path_input, path_output

  ;针对netcdf数据实现全球海温数据的中国海区的切割
  ;并将像元的经纬度信息作为变量包含进去
  ;编写日期 2015-11-16
  ;修订日期：2017-05-27    针对2016年以后数据的定标参数与以前不同，将固定定标参数修正了根据属性自动定标计算
  DEVICE,get_decomposed=odbc
  TVLCT,red,green,blue,/get

  DEVICE,decomposed=0
  LOADCT,13

  MyRootDir = path_input
  files = FILE_SEARCH(MyRootDir+'\?2017*.nc',count=num);

  ;****首先要了解MODIS 4km产品的网格特点，其全球产品大小为 [8640, 4320]
  ;    网格点经纬度步长为0.0416667，左下角点的经度为-180加上半个步长大小（即 -179.97917）
  ;    左下角纬度为90减去个步长大小   （即 89.979164）  注：图像倒置的

  step=0.0416667d

  lat=FLTARR(648,577)    ;529------------->648,增119像元
  lon=FLTARR(648,577)
  FOR j=0L,576 DO lat[0,j]=41.145790-j*step
  FOR j=0L,647 DO lat[j,*]=lat[0,*]
  ; tvscl,lat

  FOR i=0L,647 DO lon[i,0]=105.14607+i*step
  FOR i=0L,576 DO lon[*,i]=lon[*,0]
  ;  tvscl,lon

  IF num GT 0 THEN BEGIN   ;计算平均值
    PRINT,'the number of SST files is',num
    PRINT,files
    FOR i=0,num-1 DO BEGIN

      nid = NCDF_OPEN(files[i], /nowrite )
      sstid = NCDF_VARID(nid, 'sst')
      NCDF_ATTGET,nid,sstid,'scale_factor',scale_factor   ;或者变量sst里名为scale_factor的属性，存放如scale_factor中
      NCDF_ATTGET,nid,sstid,'add_offset',add_offset   ;或者变量sst里名为add_offset的属性，存放如add_offset中

      NCDF_VARGET, nid, sstid, sst
      sst=sst[6843:7490,1172:1748]
      sst=sst*scale_factor+add_offset

      NCDF_CLOSE,nid

      PRINT,i

      PRINT,MAX(sst)

      fn=FILE_BASENAME(files[i],'.nc')
      fp = path_output
      fn_new=fp+'\'+fn+'_China.hdf'

      hdfid2=HDF_SD_START(fn_new,/creat)
      varid=HDF_SD_CREATE(hdfid2,'SST',[648,577],/float)
      varid1=HDF_SD_CREATE(hdfid2,'Latitude',[648,577],/float)
      varid2=HDF_SD_CREATE(hdfid2,'Longitude',[648,577],/float)
      HDF_SD_ADDDATA,varid,sst
      HDF_SD_ADDDATA,varid1,lat
      HDF_SD_ADDDATA,varid2,lon
      HDF_SD_ENDACCESS,varid
      HDF_SD_ENDACCESS,varid1
      HDF_SD_ENDACCESS,varid2
      HDF_SD_END,hdfid2

    ENDFOR
  ENDIF

  PRINT,MAX(sst)
  PRINT,MIN(sst)

END