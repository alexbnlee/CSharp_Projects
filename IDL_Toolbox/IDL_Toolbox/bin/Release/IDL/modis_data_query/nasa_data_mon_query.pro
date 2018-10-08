;地点：OFFICE
;作者：李炳南
;时间：2018-02-06
;说明：实现下载地址自动生成相应文件
;+
; :Params:year--查询的年份
; :Params:NAD_str--要素缩写，sst、chlor、chlocx等
; :Params:MERGE--将网址均写入一个文件中
;-
PRO NASA_DATA_MON_QUERY, year, NAD_str, MERGE=merge, OF_SAVE=of_save

  ;初始化envi以及envi状态窗体
  envi, /restore_base_save_files
  envi_batch_init

  ;年份，字符串也可以用作数字使用
  YEAR = year

  envi_str = '正在处理'+strtrim(year,2)+'年数据('+strtrim(!YEAR_START,2)+$
    '年-'+strtrim(!YEAR_END,2)+'年)...'

  ;窗体内容初始化
  envi_report_init, envi_str, title='MODIS_MON 数据查找 ('+$
    STRTRIM((year-!YEAR_START+1),2)+'/'+$
    STRTRIM((!YEAR_END-!YEAR_START+1), 2)+')', base = base
  ;设置窗体的增量数，总数相当于100%，前面显示5%，后面占95%
  envi_report_inc, base, 12*2.2
  ;设置当前显示的量，所占的百分比
  envi_report_stat, base, 12*0.2, 12*2.2

  RUNDIR=!SERVER_DIR
  PRINT, '***开始处理' + STRTRIM(year, 2) + '年数据***'

  ;不同变量说明
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

  ;会存在A2012017的匹配，因此需要加入?表示单个字符
  fnw = '\?' + STRTRIM(year, 2) + '*' + NAD + '.nc'
  files_server = FILE_SEARCH(rundir + fnw, /test_regular, count=num_server)

  if keyword_set(of_save) then begin
    ;写入已存在数据
    fp_of = !SITES_DIR + '\原始数据_MON_' + STRUPCASE(NAD_str) + '.txt'
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

  ;定义月份数量
  mon_num = 12
  PRINT, '应有数据量：24'
  PRINT, '相差数据量：', STRTRIM(24 - num_server, 2)
  files = MAKE_ARRAY(24, /string)

  ;遍历A、T
  FOR i = 0, N_ELEMENTS(TIT)-1 DO BEGIN
    ;遍历不同的月份
    FOR n = 1, mon_num DO BEGIN
      envi_report_stat, base, (i+0.2) * 12 + n, 12*2.2
      ;简单判断闰年
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

      ;文件名称
      file = TIT[i] + monstr + "." + NAD + ".nc"
      files[i * mon_num + n - 1] = file
    ENDFOR

  ENDFOR

  ;写入数据
  fn = STRUPCASE(NAD_str) + '_MON_' + STRTRIM(YEAR, 2) + '.txt'

  ;如果设置关键字，则将数据写入一个文件中，否则写入单独文件中
  IF (KEYWORD_SET(merge)) THEN BEGIN
    fp = !SITES_DIR + '\MON_' + STRUPCASE(NAD_str) + '.txt'
  ENDIF ELSE BEGIN
    fp = 'D:\IDLpro\Alex\Data\' + fn
  ENDELSE

  OPENW, lun, fp, /append, /get_lun

  ;记录不存在文件序号
  num_file = 1
  ;PRINT, '缺失数据如下所示：'

  ;遍历应有文件的每个
  FOR i = 0, mon_num*2-1 DO BEGIN
    ;用来判断是否找到了文件
    flag = 0
    ;遍历实际有的文件
    FOR j = 0, num_server-1 DO BEGIN
      ;如果找到了，则将 flag赋值为1
      ;注意，文件夹中的文件名称包含路径，需要剔除获取文件名
      tmp = FILE_BASENAME(files_server[j])
      IF (files[i] EQ tmp) THEN BEGIN
        flag = 1
      ENDIF
    ENDFOR

    ;若为0，则表示数据不存在
    IF (flag EQ 0) THEN BEGIN
      ;PRINT, 'File_', STRING(num_file, format='(I03)'), ': ', files[i]
      获取下载地址
      site="https://oceandata.sci.gsfc.nasa.gov/cgi/getfile/" + files[i]
      PRINTF, lun, site
      num_file = num_file + 1

    ENDIF

  ENDFOR

  FREE_LUN, lun
  PRINT, '***处理完毕***'
  PRINT, '------------------------'

  envi_report_init, base = base, /finish
  envi_batch_exit

END