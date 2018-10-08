;地点：OFFICE
;作者：李炳南
;时间：2018-01-29
;说明：实现下载地址自动生成相应文件，批量识别
;NASA_DATA_DAY_QUERY_BATCH, 2002, 2017, 'sst'
;sst, chlor, chlocx
;NASA_DATA_DAY_QUERY_BATCH, 'D:\CODES', 'D:\CODES', 2016, 2017, 'sst'

PRO NASA_DATA_DAY_QUERY_BATCH, path_input, path_output, year_start, year_end, NAD_str, OF_SAVE=of_save
  
  ;定义系统变量，存储下载数据内容，动态获取
  defsysv, '!SERVER_DIR', path_input
  defsysv, '!SITES_DIR', path_output
  defsysv, '!YEAR_START', year_start
  defsysv, '!YEAR_END', year_end
  defsysv, '!fp', ''
  defsysv, '!fp_of', '' ;原始数据的保存路径
  
  ;将文件删除
  fp = !SITES_DIR + '\DAY_' + STRUPCASE(NAD_str) + '.txt'
  fp_of = !SITES_DIR + '\原始数据_DAY_' + STRUPCASE(NAD_str) + '.txt'
  
  !fp = fp
  !fp_of=fp_of
  
  if FILE_TEST(fp) then begin
    FILE_DELETE, fp
  endif
  
  IF FILE_TEST(fp_of) THEN BEGIN
    FILE_DELETE, fp_of
  ENDIF
  
  ;循环
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