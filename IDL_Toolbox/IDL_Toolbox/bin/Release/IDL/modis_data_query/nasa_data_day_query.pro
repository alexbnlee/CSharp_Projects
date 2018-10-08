;�ص㣺OFFICE
;���ߣ������
;ʱ�䣺2018-02-06
;˵����ʵ�����ص�ַ�Զ�������Ӧ�ļ�
;+
; :Params:year--��ѯ�����
; :Params:NAD_str--Ҫ����д��sst��chlor��chlocx��
; :Params:MERGE--����ַ��д��һ���ļ���
;-
PRO NASA_DATA_DAY_QUERY, year, NAD_str, MERGE=merge, OF_SAVE=of_save

  ;��ʼ��envi�Լ�envi״̬����
  envi, /restore_base_save_files
  envi_batch_init
  
  ;��ݣ��ַ���Ҳ������������ʹ��
  YEAR = year

  ;��������
  year_num = 365
  ;���ж�����
  IF(YEAR MOD 4 EQ 0) THEN BEGIN
    year_num++
  ENDIF
  files = make_array(year_num * 2, /string)
  
  envi_str = '���ڴ���'+strtrim(year,2)+'������('+strtrim(!YEAR_START,2)+$
    '��-'+strtrim(!YEAR_END,2)+'��)...'
  
  ;�������ݳ�ʼ��
  envi_report_init, envi_str, title='MODIS_DAY ���ݲ��� ('+$
    STRTRIM((year-!YEAR_START+1),2)+'/'+$
    STRTRIM((!YEAR_END-!YEAR_START+1), 2)+')', base = base
  ;���ô�����������������൱��100%��ǰ����ʾ5%������ռ95%
  envi_report_inc, base, year_num*2.2
  ;���õ�ǰ��ʾ��������ռ�İٷֱ�
  envi_report_stat, base, year_num*0.2, year_num*2.2

  RUNDIR=!SERVER_DIR
  print, '***��ʼ����' + strtrim(year, 2) + '������***'

  ;��ͬ����˵��
  TIT=['A', 'T']

  CASE NAD_str OF
    'cdom': BEGIN
      NAD = 'L3m_DAY_CDOM_cdom_index_4km'
    END
    
    'chlor': BEGIN
      NAD = 'L3m_DAY_CHL_chlor_a_4km'
    END

    'chlocx': BEGIN
      NAD = 'L3m_DAY_CHL_chl_ocx_4km'
    END
    
    'flh': BEGIN
      NAD = 'L3m_DAY_FLH_ipar_4km'
    END
    
    'kd490': BEGIN
      NAD = 'L3m_DAY_KD490_Kd_490_4km'
    END
    
    'par': BEGIN
      NAD = 'L3m_DAY_PAR_par_4km'
    END
    
    'pic': BEGIN
      NAD = 'L3m_DAY_PIC_pic_4km'
    END
    
    'poc': BEGIN
      NAD = 'L3m_DAY_POC_poc_4km'
    END
    
    'poc': BEGIN
      NAD = 'L3m_DAY_POC_poc_4km'
    END
    
    'rrs488': BEGIN
      NAD = 'L3m_DAY_RRS_Rrs_488_4km'
    END
    
    'rrs531': BEGIN
      NAD = 'L3m_DAY_RRS_Rrs_531_4km'
    END
    
    'rrs547': BEGIN
      NAD = 'L3m_DAY_RRS_Rrs_547_4km'
    END
    
    'rrs645': BEGIN
      NAD = 'L3m_DAY_RRS_Rrs_645_4km'
    END
    
    'rrs667': BEGIN
      NAD = 'L3m_DAY_RRS_Rrs_667_4km'
    END
    
    'sst': BEGIN
      NAD = 'L3m_DAY_SST_sst_4km'
    END


    ELSE: BEGIN
    END
  ENDCASE

  ;�����A2012017��ƥ�䣬�����Ҫ����?��ʾ�����ַ�
  fnw = '\?' + STRTRIM(year, 2) + '*' + NAD + '.nc'
  files_server = FILE_SEARCH(rundir + fnw, /test_regular, count=num_server)
  
  if keyword_set(of_save) then begin
    ;д���Ѵ�������
    fp_of = !SITES_DIR + '\ԭʼ����_DAY_' + STRUPCASE(NAD_str) + '.txt'
    OPENW, lun, fp_of, /append, /get_lun
    PRINTF, lun, "---"+strtrim(year,2)+"����������("+$
      strtrim(N_elements(files_server),2)+")---"
    for i = 0, N_elements(files_server)-1 do begin
      printf, lun, STRtrim(i+1,2)+". "+file_basename(files_server[i])
    endfor
    printf, lun, ""
    FREE_LUN, lun
  endif
   
  PRINT, 'ʵ����������', STRTRIM(num_server, 2)
  print, 'Ӧ����������', strtrim(year_num * 2, 2)
  print, '�����������', strtrim(year_num * 2 - num_server, 2)

  ;����A��T
  FOR i = 0, N_ELEMENTS(TIT)-1 DO BEGIN
    ;������ͬ���·�
    FOR n = 1, year_num DO BEGIN
      envi_report_stat, base, (i+0.2) * year_num + n, year_num*2.2
      ;������λ�Ĳ�0
      daystr = strtrim(YEAR, 2) + string(n, format='(I03)')
      ;�ļ�����
      file = TIT[i] + daystr + "." + NAD + ".nc"
      files[i * year_num + n - 1] = file
    ENDFOR
  ENDFOR

  ;д������
  fn = STRUPCASE(NAD_str) + '_DAY_' + strtrim(YEAR, 2) + '.txt'

  ;������ùؼ��֣�������д��һ���ļ��У�����д�뵥���ļ���
  if (KEYWORD_SET(merge)) then begin
    fp = !SITES_DIR + '\DAY_' + STRUPCASE(NAD_str) + '.txt'
  endif else begin
    fp = 'D:\IDLpro\Alex\Data\' + fn
  endelse

  openw, lun, fp, /append, /get_lun

  ;��¼�������ļ����
  num_file = 1
  print, 'ȱʧ����������ʾ��'

  ;����Ӧ���ļ���ÿ��
  for i = 0, year_num*2-1 do begin
    ;�����ж��Ƿ��ҵ����ļ�
    flag = 0
    ;����ʵ���е��ļ�
    for j = 0, num_server-1 do begin
      ;����ҵ��ˣ��� flag��ֵΪ1
      ;ע�⣬�ļ����е��ļ����ư���·������Ҫ�޳���ȡ�ļ���
      tmp = FILE_BASENAME(files_server[j])
      if (files[i] eq tmp) then begin
        flag = 1
      endif
    endfor

    ;��Ϊ0�����ʾ���ݲ�����
    if (flag eq 0) then begin
      print, 'File_', string(num_file, format='(I03)'), ': ', files[i]
      ;��ȡ���ص�ַ
      site="https://oceandata.sci.gsfc.nasa.gov/cgi/getfile/" + files[i]
      printf, lun, site
      num_file = num_file + 1
    endif
  endfor

  free_lun, lun
  PRINT, '***�������***'
  print, '------------------------'

  envi_report_init, base = base, /finish
  envi_batch_exit

END