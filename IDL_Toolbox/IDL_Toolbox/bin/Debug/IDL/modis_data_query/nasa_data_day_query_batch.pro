;�ص㣺OFFICE
;���ߣ������
;ʱ�䣺2018-01-29
;˵����ʵ�����ص�ַ�Զ�������Ӧ�ļ�������ʶ��
;NASA_DATA_DAY_QUERY_BATCH, 2002, 2017, 'sst'
;sst, chlor, chlocx
;NASA_DATA_DAY_QUERY_BATCH, 'D:\CODES', 'D:\CODES', 2016, 2017, 'sst'

PRO NASA_DATA_DAY_QUERY_BATCH, path_input, path_output, year_start, year_end, NAD_str, OF_SAVE=of_save
  
  ;����ϵͳ�������洢�����������ݣ���̬��ȡ
  defsysv, '!SERVER_DIR', path_input
  defsysv, '!SITES_DIR', path_output
  defsysv, '!YEAR_START', year_start
  defsysv, '!YEAR_END', year_end
  defsysv, '!fp', ''
  defsysv, '!fp_of', '' ;ԭʼ���ݵı���·��
  
  ;���ļ�ɾ��
  fp = !SITES_DIR + '\DAY_' + STRUPCASE(NAD_str) + '.txt'
  fp_of = !SITES_DIR + '\ԭʼ����_DAY_' + STRUPCASE(NAD_str) + '.txt'
  
  !fp = fp
  !fp_of=fp_of
  
  if FILE_TEST(fp) then begin
    FILE_DELETE, fp
  endif
  
  IF FILE_TEST(fp_of) THEN BEGIN
    FILE_DELETE, fp_of
  ENDIF
  
  ;ѭ��
  if keyword_set(of_save) then begin
    FOR i = year_start, year_end DO BEGIN
      NASA_DATA_DAY_QUERY, i, NAD_str, /MERGE, /OF_SAVE
    ENDFOR
  endif else begin
    FOR i = year_start, year_end DO BEGIN
      NASA_DATA_DAY_QUERY, i, NAD_str, /MERGE
    ENDFOR
  endelse

end