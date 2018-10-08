PRO ZHEJIANG_SST_FROM_GLOBAL_NC, path_input, path_output

  ;ʵ��ȫ��4km��nc�������ݵ��㽭�������и�
  ;������Ԫ�ľ�γ����Ϣ��Ϊ����������ȥ
  ;�������ڣ�2017-10-14
  ;�޶����ڣ�2017-10-14
  DEVICE,get_decomposed=odbc
  TVLCT,red,green,blue,/get

  DEVICE,decomposed=0
  LOADCT,13
  ;  file='E:\A20092442009273.L3m_MO_SST_4'

  MyRootDir=path_input
  files = FILE_SEARCH(MyRootDir+'\*.nc',count=num);

  step=0.0416667d

  sample=160   ;�����㽭�����С
  line=175

  UL_SAMPLE=6843 ;ȡ��(�й�����)ͼ�����ϵ��к�
  UL_LIEN=1172  ;ȡ��(�й�����)ͼ�����ϵ��к�


  U_lat= 89.979164-STEP*(UL_LIEN+201)  ;������ú��㽭����ͼ�������γ��
  L_lon= -179.97917+step*(UL_SAMPLE+316);������ú��㽭����ͼ������󾭶�

  ;****����Ҫ�˽�MODIS 4km��Ʒ�������ص㣬��ȫ���Ʒ��СΪ [8640, 4320]
  ;    ����㾭γ�Ȳ���Ϊ0.0416667�����½ǵ�ľ���Ϊ-180���ϰ��������С���� -179.97917��
  ;    ���½�γ��Ϊ90��ȥ��������С   ���� 89.979164��  ע��ͼ���õ�
  ;


  lat=FLTARR(sample,line)    ;529------------->648,��119��Ԫ
  lon=FLTARR(sample,line)

  FOR j=0L,line-1 DO lat[0,j]=U_lat-j*step
  FOR j=0L,sample-1 DO lat[j,*]=lat[0,*]
  ; tvscl,lat

  FOR i=0L,sample-1 DO lon[i,0]=L_lon+i*step
  FOR i=0L,line-1 DO lon[*,i]=lon[*,0]
  ;  tvscl,lon


  IF num GT 0 THEN BEGIN   ;����ƽ��ֵ
    PRINT,'the number of SST files is',num
    PRINT,files
    FOR i=0,num-1 DO BEGIN

      nid = NCDF_OPEN(files[i], /nowrite )
      sstid = NCDF_VARID(nid, 'sst')
      NCDF_ATTGET,nid,sstid,'scale_factor',scale_factor   ;���߱���sst����Ϊscale_factor�����ԣ������scale_factor��
      NCDF_ATTGET,nid,sstid,'add_offset',add_offset   ;���߱���sst����Ϊadd_offset�����ԣ������add_offset��

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