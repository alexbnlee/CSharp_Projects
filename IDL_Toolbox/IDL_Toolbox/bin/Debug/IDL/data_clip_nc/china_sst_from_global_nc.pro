PRO CHINA_SST_FROM_GLOBAL_NC, path_input, path_output

  ;���netcdf����ʵ��ȫ�������ݵ��й��������и�
  ;������Ԫ�ľ�γ����Ϣ��Ϊ����������ȥ
  ;��д���� 2015-11-16
  ;�޶����ڣ�2017-05-27    ���2016���Ժ����ݵĶ����������ǰ��ͬ�����̶�������������˸��������Զ��������
  DEVICE,get_decomposed=odbc
  TVLCT,red,green,blue,/get

  DEVICE,decomposed=0
  LOADCT,13

  MyRootDir = path_input
  files = FILE_SEARCH(MyRootDir+'\?2017*.nc',count=num);

  ;****����Ҫ�˽�MODIS 4km��Ʒ�������ص㣬��ȫ���Ʒ��СΪ [8640, 4320]
  ;    ����㾭γ�Ȳ���Ϊ0.0416667�����½ǵ�ľ���Ϊ-180���ϰ��������С���� -179.97917��
  ;    ���½�γ��Ϊ90��ȥ��������С   ���� 89.979164��  ע��ͼ���õ�

  step=0.0416667d

  lat=FLTARR(648,577)    ;529------------->648,��119��Ԫ
  lon=FLTARR(648,577)
  FOR j=0L,576 DO lat[0,j]=41.145790-j*step
  FOR j=0L,647 DO lat[j,*]=lat[0,*]
  ; tvscl,lat

  FOR i=0L,647 DO lon[i,0]=105.14607+i*step
  FOR i=0L,576 DO lon[*,i]=lon[*,0]
  ;  tvscl,lon

  IF num GT 0 THEN BEGIN   ;����ƽ��ֵ
    PRINT,'the number of SST files is',num
    PRINT,files
    FOR i=0,num-1 DO BEGIN

      nid = NCDF_OPEN(files[i], /nowrite )
      sstid = NCDF_VARID(nid, 'sst')
      NCDF_ATTGET,nid,sstid,'scale_factor',scale_factor   ;���߱���sst����Ϊscale_factor�����ԣ������scale_factor��
      NCDF_ATTGET,nid,sstid,'add_offset',add_offset   ;���߱���sst����Ϊadd_offset�����ԣ������add_offset��

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