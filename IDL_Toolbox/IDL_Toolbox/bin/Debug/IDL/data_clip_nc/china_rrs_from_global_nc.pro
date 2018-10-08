PRO China_RRS_from_Global_nc, path_input, path_output

  ;���netcdf����ʵ��ȫ��ң�з����ʵ��й��������и�
  ;������Ԫ�ľ�γ����Ϣ��Ϊ����������ȥ
  ;��д���� 2016-01-11
  ;�޶����ڣ�2016-01-11
  DEVICE,get_decomposed=odbc
  TVLCT,red,green,blue,/get

  DEVICE,decomposed=0
  loadct,13

  MyRootDir=path_input
  files = FILE_SEARCH(MyRootDir+'\*.nc',count=num);
  str='Rrs_645'




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
      chl_id = NCDF_VARID(nid, str)



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
      varid=HDF_SD_CREATE(hdfid2,str,[648,577],/float)
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

  ;tvscl,sst,order=1




  ;  att1name=hdf_sd_attdir(hdfid,varname[1])
  ;  attname=hdf_sd_attdir(hdfid,'')   ;���ȫ������

  ; ��ȡȫ��������
  ;  natt=n_elements(attname)
  ;    for i=0,natt-1 do $
  ;  print,attname[i]
  ;  help,natt
  ;��ȡȫ�����Ե�����
  ;  for i=0,natt-1 do begin
  ;  hdf_sd_attread,hdfid,'',attname[i],data
  ;  help,data
  ;  print,data
  ;  endfor
  ;  ******************
  ;
  ;  for i=0,natt-1 do begin
  ;    attindex=hdf_sd_attrfind(hdfid,attname[i])
  ;    hdf_sd_attrinfo,hdfid,attindex,data=attvalue
  ;    print,attvalue
  ;  endfor
  ;;  HELP,ATTNAME
  ;;  for i=0,n0att-1 do begin
  ;;    print,'the',strcompress(i+1),' attribute is:'
  ;;    print,att0name[i]
  ;;  endfor
  ;  n1att=n_elements(att1name)
  ;    for i=0,n1att-1 do begin
  ;    print,'the',strcompress(i+1),' attribute is:'
  ;    print,att1name[i]
  ;  endfor
  ;  hdf_sd_attread,hdfid,varname[1],att1name[0],att1
  ;  hdf_sd_end,hdfid
  ;  help,att1
  ;  print,att1
  ;HELP,ATT1
  ;д���ļ�
  ;���徭γ������


  ;
  ;hdf_sd_attrset,varid,'file_name','monthly sst for 10 years'
  ;hdf_sd_attrset,hdfid,'Map Projection','Equidistant Cylindriacl'
  ;hdf_sd_attrset,hdfid,'Latitude Units','degrees North'
  ;hdf_sd_attrset,hdfid,'Longitude Units','degrees East'
  ;hdf_sd_attrset,hdfid,'L2 Flag','LAND,HISOLZ'
  ;hdf_sd_attrset,hdfid,'Northrnmost Latitude',41.1667
  ;;hdf_sd_attrset,hdfid,'Eastrnmost Longitude',41.1667
  ;hdf_sd_attrset,hdfid,'SW Latitude',17.1875
  ;hdf_sd_attrset,hdfid,'SW Longitude',105.146
  ;hdf_sd_attrset,hdfid,'Latitude Step',0.0416667
  ;hdf_sd_attrset,hdfid,'Longitude Step',0.0416667
  ;hdf_sd_end,hdfid

  PRINT,MAX(chl)
  PRINT,MIN(chl)

END