PRO China_CHL_from_Global_nc, path_input, path_output

  ;���netcdf����ʵ��ȫ�������ݵ��й��������и�
  ;������Ԫ�ľ�γ����Ϣ��Ϊ����������ȥ
  ;��д���� 2016-01-11
  ;�޶����ڣ�2016-01-11
  DEVICE,get_decomposed=odbc
  TVLCT,red,green,blue,/get

  DEVICE,decomposed=0
  loadct,13

  MyRootDir=path_input
  files = FILE_SEARCH(MyRootDir+'\*.nc',count=num);





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
    PRINT,'the number of files is',num
    PRINT,files
    FOR i=0,num-1 DO BEGIN

      nid = NCDF_OPEN(files[i], /nowrite )
      chl_id = NCDF_VARID(nid, 'chlor_a')



      NCDF_VARGET, nid, chl_id, chl
      chl=chl[6843:7490,1172:1748]

      NCDF_CLOSE,nid



      ;      att0name=hdf_sd_attdir(hdfid,varname[0]) ;��õ�1��������������

      ;      hdf_sd_attread,hdfid,varname[0],att0name[3],intercept  ;��ȡ���Թ�ϵ�Ľؾ�
      ;      hdf_sd_attread,hdfid,varname[0],att0name[2],slope   ;��ȡ���Թ�ϵ��б��
      ;      print,intercept
      PRINT,i

      PRINT,MAX(chl)
      ;      dis=where((sst ge -5.0) and (sst lt 40.0))
      ;      print,min(sst)


      fn=FILE_BASENAME(files[i],'.nc')
      fp=path_output
      fn_new=fp+'\'+fn+'_China.hdf'

      hdfid2=HDF_SD_START(fn_new,/creat)
      varid=HDF_SD_CREATE(hdfid2,'CHL_A',[648,577],/float)
      varid1=HDF_SD_CREATE(hdfid2,'Latitude',[648,577],/float)
      varid2=HDF_SD_CREATE(hdfid2,'Longitude',[648,577],/float)
      HDF_SD_ADDDATA,varid,chl
      HDF_SD_ADDDATA,varid1,lat
      HDF_SD_ADDDATA,varid2,lon
      HDF_SD_ENDACCESS,varid
      HDF_SD_ENDACCESS,varid1
      HDF_SD_ENDACCESS,varid2
      HDF_SD_END,hdfid2

    ENDFOR
  ENDIF

  

  PRINT,MAX(chl)
  PRINT,MIN(chl)

END