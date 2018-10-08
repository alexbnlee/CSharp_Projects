;�ص㣺OFFICE
;���ߣ������
;ʱ�䣺2018-02-06
;˵����ʵ�����ص�ַ�Զ�������Ӧ�ļ�
;+
; :Params:year--��ѯ�����
; :Params:NAD_str--Ҫ����д��sst��chlor��chlocx��
; :Params:MERGE--����ַ��д��һ���ļ���
;-
PRO NASA_DATA_MON_QUERY, year, NAD_str, MERGE=merge, OF_SAVE=of_save

  ;��ʼ��envi�Լ�envi״̬����
  envi, /restore_base_save_files
  envi_batch_init

  ;��ݣ��ַ���Ҳ������������ʹ��
  YEAR = year

  envi_str = '���ڴ���'+strtrim(year,2)+'������('+strtrim(!YEAR_START,2)+$
    '��-'+strtrim(!YEAR_END,2)+'��)...'

  ;�������ݳ�ʼ��
  envi_report_init, envi_str, title='MODIS_MON ���ݲ��� ('+$
    STRTRIM((year-!YEAR_START+1),2)+'/'+$
    STRTRIM((!YEAR_END-!YEAR_START+1), 2)+')', base = base
  ;���ô�����������������൱��100%��ǰ����ʾ5%������ռ95%
  envi_report_inc, base, 12*2.2
  ;���õ�ǰ��ʾ��������ռ�İٷֱ�
  envi_report_stat, base, 12*0.2, 12*2.2

  RUNDIR=!SERVER_DIR
  PRINT, '***��ʼ����' + STRTRIM(year, 2) + '������***'

  ;��ͬ����˵��
  TIT=['A', 'T']

  CASE NAD_str OF
    'cdom': BEGIN
      NAD = 'L3m_MO_CDOM_cdom_index_4km'
    END

    'chlor': BEGIN
      NAD = 'L3m_MO_CHL_chlor_a_4km'
    END

    'chlocx': BEGIN
      NAD = 'L3m_MO_CHL_chl_ocx_4km'
    END

    'flh': BEGIN
      NAD = 'L3m_MO_FLH_ipar_4km'
    END

    'kd490': BEGIN
      NAD = 'L3m_MO_KD490_Kd_490_4km'
    END

    'par': BEGIN
      NAD = 'L3m_MO_PAR_par_4km'
    END

    'pic': BEGIN
      NAD = 'L3m_MO_PIC_pic_4km'
    END

    'poc': BEGIN
      NAD = 'L3m_MO_POC_poc_4km'
    END

    'poc': BEGIN
      NAD = 'L3m_MO_POC_poc_4km'
    END

    'rrs488': BEGIN
      NAD = 'L3m_MO_RRS_Rrs_488_4km'
    END

    'rrs531': BEGIN
      NAD = 'L3m_MO_RRS_Rrs_531_4km'
    END

    'rrs547': BEGIN
      NAD = 'L3m_MO_RRS_Rrs_547_4km'
    END

    'rrs645': BEGIN
      NAD = 'L3m_MO_RRS_Rrs_645_4km'
    END

    'rrs667': BEGIN
      NAD = 'L3m_MO_RRS_Rrs_667_4km'
    END

    'sst': BEGIN
      NAD = 'L3m_MO_SST_sst_4km'
    END

    ELSE: BEGIN
    END
  ENDCASE

  ;�����A2012017��ƥ�䣬�����Ҫ����?��ʾ�����ַ�
  fnw = '\?' + STRTRIM(year, 2) + '*' + NAD + '.nc'
  files_server = FILE_SEARCH(rundir + fnw, /test_regular, count=num_server)

  if keyword_set(of_save) then begin
    ;д���Ѵ�������
    fp_of = !SITES_DIR + '\ԭʼ����_MON_' + STRUPCASE(NAD_str) + '.txt'
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

  ;�����·�����
  mon_num = 12
  PRINT, 'Ӧ����������24'
  PRINT, '�����������', STRTRIM(24 - num_server, 2)
  files = MAKE_ARRAY(24, /string)

  ;����A��T
  FOR i = 0, N_ELEMENTS(TIT)-1 DO BEGIN
    ;������ͬ���·�
    FOR n = 1, mon_num DO BEGIN
      envi_report_stat, base, (i+0.2) * 12 + n, 12*2.2
      ;���ж�����
      IF (YEAR MOD 4 EQ 0) THEN BEGIN
        CASE n OF
          1: monstr = STRTRIM(YEAR, 2)+'001'+STRTRIM(YEAR, 2)+'031'
          2: monstr = STRTRIM(YEAR, 2)+'032'+STRTRIM(YEAR, 2)+'060'
          3: monstr = STRTRIM(YEAR, 2)+'061'+STRTRIM(YEAR, 2)+'091'
          4: monstr = STRTRIM(YEAR, 2)+'092'+STRTRIM(YEAR, 2)+'121'
          5: monstr = STRTRIM(YEAR, 2)+'122'+STRTRIM(YEAR, 2)+'152'
          6: monstr = STRTRIM(YEAR, 2)+'153'+STRTRIM(YEAR, 2)+'182'
          7: monstr = STRTRIM(YEAR, 2)+'183'+STRTRIM(YEAR, 2)+'213'
          8: monstr = STRTRIM(YEAR, 2)+'214'+STRTRIM(YEAR, 2)+'244'
          9: monstr = STRTRIM(YEAR, 2)+'245'+STRTRIM(YEAR, 2)+'274'
          10: monstr = STRTRIM(YEAR, 2)+'275'+STRTRIM(YEAR, 2)+'305'
          11: monstr = STRTRIM(YEAR, 2)+'306'+STRTRIM(YEAR, 2)+'335'
          12: monstr = STRTRIM(YEAR, 2)+'336'+STRTRIM(YEAR, 2)+'366'
          ELSE:
        ENDCASE
      ENDIF ELSE BEGIN
        CASE n OF
          1: monstr = STRTRIM(YEAR, 2)+'001'+STRTRIM(YEAR, 2)+'031'
          2: monstr = STRTRIM(YEAR, 2)+'032'+STRTRIM(YEAR, 2)+'059'
          3: monstr = STRTRIM(YEAR, 2)+'060'+STRTRIM(YEAR, 2)+'090'
          4: monstr = STRTRIM(YEAR, 2)+'091'+STRTRIM(YEAR, 2)+'120'
          5: monstr = STRTRIM(YEAR, 2)+'121'+STRTRIM(YEAR, 2)+'151'
          6: monstr = STRTRIM(YEAR, 2)+'152'+STRTRIM(YEAR, 2)+'181'
          7: monstr = STRTRIM(YEAR, 2)+'182'+STRTRIM(YEAR, 2)+'212'
          8: monstr = STRTRIM(YEAR, 2)+'213'+STRTRIM(YEAR, 2)+'243'
          9: monstr = STRTRIM(YEAR, 2)+'244'+STRTRIM(YEAR, 2)+'273'
          10: monstr = STRTRIM(YEAR, 2)+'274'+STRTRIM(YEAR, 2)+'304'
          11: monstr = STRTRIM(YEAR, 2)+'305'+STRTRIM(YEAR, 2)+'334'
          12: monstr = STRTRIM(YEAR, 2)+'335'+STRTRIM(YEAR, 2)+'365'
          ELSE:
        ENDCASE
      ENDELSE

      ;�ļ�����
      file = TIT[i] + monstr + "." + NAD + ".nc"
      files[i * mon_num + n - 1] = file
    ENDFOR

  ENDFOR

  ;д������
  fn = STRUPCASE(NAD_str) + '_MON_' + STRTRIM(YEAR, 2) + '.txt'

  ;������ùؼ��֣�������д��һ���ļ��У�����д�뵥���ļ���
  IF (KEYWORD_SET(merge)) THEN BEGIN
    fp = !SITES_DIR + '\MON_' + STRUPCASE(NAD_str) + '.txt'
  ENDIF ELSE BEGIN
    fp = 'D:\IDLpro\Alex\Data\' + fn
  ENDELSE

  OPENW, lun, fp, /append, /get_lun

  ;��¼�������ļ����
  num_file = 1
  ;PRINT, 'ȱʧ����������ʾ��'

  ;����Ӧ���ļ���ÿ��
  FOR i = 0, mon_num*2-1 DO BEGIN
    ;�����ж��Ƿ��ҵ����ļ�
    flag = 0
    ;����ʵ���е��ļ�
    FOR j = 0, num_server-1 DO BEGIN
      ;����ҵ��ˣ��� flag��ֵΪ1
      ;ע�⣬�ļ����е��ļ����ư���·������Ҫ�޳���ȡ�ļ���
      tmp = FILE_BASENAME(files_server[j])
      IF (files[i] EQ tmp) THEN BEGIN
        flag = 1
      ENDIF
    ENDFOR

    ;��Ϊ0�����ʾ���ݲ�����
    IF (flag EQ 0) THEN BEGIN
      ;PRINT, 'File_', STRING(num_file, format='(I03)'), ': ', files[i]
      ��ȡ���ص�ַ
      site="https://oceandata.sci.gsfc.nasa.gov/cgi/getfile/" + files[i]
      PRINTF, lun, site
      num_file = num_file + 1

    ENDIF

  ENDFOR

  FREE_LUN, lun
  PRINT, '***�������***'
  PRINT, '------------------------'

  envi_report_init, base = base, /finish
  envi_batch_exit

END