;地点：OFFICE
;作者：李炳南
;时间：2018-02-06
;说明：实现下载地址自动生成相应文件
;+
; :Params:year--查询的年份
; :Params:NAD_str--要素缩写，sst、chlor、chlocx等
; :Params:MERGE--将网址均写入一个文件中
;-
PRO NASA_DATA_DAY_QUERY, year, NAD_str, MERGE=merge, OF_SAVE=of_save

  ;初始化envi以及envi状态窗体
  envi, /restore_base_save_files
  envi_batch_init
  
  ;年份，字符串也可以用作数字使用
  YEAR = year

  ;定义天数
  year_num = 365
  ;简单判断闰年
  IF(YEAR MOD 4 EQ 0) THEN BEGIN
    year_num++
  ENDIF
  files = make_array(year_num * 2, /string)
  
  envi_str = '正在处理'+strtrim(year,2)+'年数据('+strtrim(!YEAR_START,2)+$
    '年-'+strtrim(!YEAR_END,2)+'年)...'
  
  ;窗体内容初始化
  envi_report_init, envi_str, title='MODIS_DAY 数据查找 ('+$
    STRTRIM((year-!YEAR_START+1),2)+'/'+$
    STRTRIM((!YEAR_END-!YEAR_START+1), 2)+')', base = base
  ;设置窗体的增量数，总数相当于100%，前面显示5%，后面占95%
  envi_report_inc, base, year_num*2.2
  ;设置当前显示的量，所占的百分比
  envi_report_stat, base, year_num*0.2, year_num*2.2

  RUNDIR=!SERVER_DIR
  print, '***开始处理' + strtrim(year, 2) + '年数据***'

  ;不同变量说明
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

  ;会存在A2012017的匹配，因此需要加入?表示单个字符
  fnw = '\?' + STRTRIM(year, 2) + '*' + NAD + '.nc'
  files_server = FILE_SEARCH(rundir + fnw, /test_regular, count=num_server)
  
  if keyword_set(of_save) then begin
    ;写入已存在数据
    fp_of = !SITES_DIR + '\原始数据_DAY_' + STRUPCASE(NAD_str) + '.txt'
    OPENW, lun, fp_of, /append, /get_lun
    PRINTF, lun, "---"+strtrim(year,2)+"年数据如下("+$
      strtrim(N_elements(files_server),2)+")---"
    for i = 0, N_elements(files_server)-1 do begin
      printf, lun, STRtrim(i+1,2)+". "+file_basename(files_server[i])
    endfor
    printf, lun, ""
    FREE_LUN, lun
  endif
   
  PRINT, '实际数据量：', STRTRIM(num_server, 2)
  print, '应有数据量：', strtrim(year_num * 2, 2)
  print, '相差数据量：', strtrim(year_num * 2 - num_server, 2)

  ;遍历A、T
  FOR i = 0, N_ELEMENTS(TIT)-1 DO BEGIN
    ;遍历不同的月份
    FOR n = 1, year_num DO BEGIN
      envi_report_stat, base, (i+0.2) * year_num + n, year_num*2.2
      ;不满三位的补0
      daystr = strtrim(YEAR, 2) + string(n, format='(I03)')
      ;文件名称
      file = TIT[i] + daystr + "." + NAD + ".nc"
      files[i * year_num + n - 1] = file
    ENDFOR
  ENDFOR

  ;写入数据
  fn = STRUPCASE(NAD_str) + '_DAY_' + strtrim(YEAR, 2) + '.txt'

  ;如果设置关键字，则将数据写入一个文件中，否则写入单独文件中
  if (KEYWORD_SET(merge)) then begin
    fp = !SITES_DIR + '\DAY_' + STRUPCASE(NAD_str) + '.txt'
  endif else begin
    fp = 'D:\IDLpro\Alex\Data\' + fn
  endelse

  openw, lun, fp, /append, /get_lun

  ;记录不存在文件序号
  num_file = 1
  print, '缺失数据如下所示：'

  ;遍历应有文件的每个
  for i = 0, year_num*2-1 do begin
    ;用来判断是否找到了文件
    flag = 0
    ;遍历实际有的文件
    for j = 0, num_server-1 do begin
      ;如果找到了，则将 flag赋值为1
      ;注意，文件夹中的文件名称包含路径，需要剔除获取文件名
      tmp = FILE_BASENAME(files_server[j])
      if (files[i] eq tmp) then begin
        flag = 1
      endif
    endfor

    ;若为0，则表示数据不存在
    if (flag eq 0) then begin
      print, 'File_', string(num_file, format='(I03)'), ': ', files[i]
      ;获取下载地址
      site="https://oceandata.sci.gsfc.nasa.gov/cgi/getfile/" + files[i]
      printf, lun, site
      num_file = num_file + 1
    endif
  endfor

  free_lun, lun
  PRINT, '***处理完毕***'
  print, '------------------------'

  envi_report_init, base = base, /finish
  envi_batch_exit

END