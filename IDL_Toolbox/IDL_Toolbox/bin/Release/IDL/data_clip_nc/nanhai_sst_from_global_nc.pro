PRO Nanhai_SST_from_Global_nc, path_input, path_output

  ;���netcdf����ʵ��ȫ�������ݵ��Ϻ��������иΪ������ɺ�����׻�׼��
  ;������Ԫ�ľ�γ����Ϣ��Ϊ����������ȥ
  ;��д���� 2017-07-11
  ;�޶����ڣ�2017-07-11    ���2016���Ժ����ݵĶ����������ǰ��ͬ�����̶�������������˸��������Զ��������
  DEVICE,get_decomposed=odbc
  TVLCT,red,green,blue,/get

  DEVICE,decomposed=0
  loadct,13

  MyRootDir=path_input
  files = FILE_SEARCH(MyRootDir+'\*.nc',count=num);


  step=0.0416667d

  sample=648-218  ;������ú�ͼ��ľ��߳�
  line=673   ;������ú�ͼ���γ�߳�
  
  LU_SAMPLE=6843 ;ȡ��ͼ�����ϵ��к�
  LU_LIEN=1500  ;ȡ��ͼ�����ϵ��к�
  
  U_lat= 17.45771+STEP*248  ;������ú�ͼ�������γ��
  L_lon= 105.14607 ;������ú�ͼ������󾭶�  

  ;****����Ҫ�˽�MODIS 4km��Ʒ�������ص㣬��ȫ���Ʒ��СΪ [8640, 4320]
  ;    ����㾭γ�Ȳ���Ϊ0.0416667�����½ǵ�ľ���Ϊ-180���ϰ��������С���� -179.97917��
  ;    ���½�γ��Ϊ90��ȥ��������С   ���� 89.979164��  ע��ͼ���õ�


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
      sst=sst[LU_SAMPLE:LU_SAMPLE+sample-1,LU_LIEN:LU_LIEN+line-1]
      sst=sst*scale_factor+add_offset

      NCDF_CLOSE,nid


      ;      att0name=hdf_sd_attdir(hdfid,varname[0]) ;��õ�1��������������

      ;      hdf_sd_attread,hdfid,varname[0],att0name[3],intercept  ;��ȡ���Թ�ϵ�Ľؾ�
      ;      hdf_sd_attread,hdfid,varname[0],att0name[2],slope   ;��ȡ���Թ�ϵ��б��
      ;      print,intercept
      PRINT,i

      PRINT,MAX(sst)
      ;      dis=where((sst ge -5.0) and (sst lt 40.0))
      ;      print,min(sst)


      fn=FILE_BASENAME(files[i],'.nc')
      fp=path_output
      fn_new=fp+'\'+fn+'_Nanhai.hdf'

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

  PRINT,MAX(sst)
  PRINT,MIN(sst)

END