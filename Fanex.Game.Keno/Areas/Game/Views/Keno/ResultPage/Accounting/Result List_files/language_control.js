function lc(v, lg) {
    var _lc = {
        // General
        'bs_b': 'Big:大:大',
        'bs_s': 'Small:小:小',
        'oe_o': 'Odd:单:單',
        'oe_e': 'Even:双:雙',
        'ud_u': 'Up:上:上',
        'ud_t': 'Tie:中:中',
        'ud_d': 'Down:下:下',
        'soe_sot': 'Star Odd:星单:星單',
        'soe_set': 'Star Even:星双:星雙',
        'soe_sot_sh': 'S.Odd:星单:星單',
        'soe_set_sh': 'S.Even:星双:星雙',
        'oes_os': 'Odds:奇:奇',
        'oes_ts': 'Ties:中:中',
        'oes_es': 'Evens:偶:偶',
        'bsoe_bo': 'Big Odd:大单:大單',
        'bsoe_be': 'Big Even:大双:大雙',
        'bsoe_so': 'Small Odd:小单:小單',
        'bsoe_se': 'Small Even:小双:小雙',
        'fe_g': 'Gold:金:金',
        'fe_wd': 'Wood:木:木',
        'fe_wt': 'Water:水:水',
        'fe_f': 'Fire:火:火',
        'fe_ea': 'Earth:土:土',
        'dt_dr': 'Dragon:龙:龍',
        'dt_dt': 'DT-Tie:和:和',
        'dt_ti': 'Tiger:虎:虎',
        'dt_drb': 'D.Big:龙大:龍大',
        'dt_drs': 'D.Small:龙小:龍小',
        'dt_dro': 'D.Odd:龙单:龍單',
        'dt_dre': 'D.Even:龙双:龍雙',
        'dt_tib': 'T.Big:虎大:虎大',
        'dt_tis': 'T.Small:虎小:虎小',
        'dt_tio': 'T.Odd:虎单:虎單',
        'dt_tie': 'T.Even:虎双:虎雙',


        //A
        'ACCOUNT': 'Account:账号:帳號',
        'ANNOUNCEMENT': 'Announcement:消息公布:消息公佈',
        'AVAILABLE_FUND': 'Available Fund:额度:額度',
        //B
        'BET_LIMIT': 'Bet Limit:限额:限額',
        'BET': 'Bet:下注:下注',
        //C
        'CANCEL': 'Cancel:取消:取消',
        'CLOSE': 'Close:关闭:關閉',
        'CATEGORY': 'Category:类别:類別',
        //D
        'DRAW_NO': 'Draw No:期数:期數',
        'DATE': 'Date:日期:日期',
        'DT_TENS': 'Tens:十位数:十位數',
        'DT_UNITS': 'Units:个位数:個位數',
        //E
        'ERROR_MIN_TO': 'Sorry, your stake cannot lower than minimum limit!:对不起，您的注额不能小于最低注额!:對不起，您的注額不能小於最低注額!',
        'ERROR_MAX_TO': 'Sorry, your stake cannot higher than maximum limit!:对不起，您的注额不能超过最高注额!:對不起，您的注額不能超過最高注額!',
        'ERROR_TO': 'Sorry, Please key in your stake again!:对不起，请输入您的注额！:對不起，請輸入您的注額！',
        'ERROR_XLIMIT': 'Sorry, This game already over limit! Welcome to try on other game!:对不起，这局游戏注额已经超过额度，欢迎您下局再来玩！:對不起，這局遊戲注額已經超過額度，歡迎您下局再來玩！',
        'ERROR_XAMOUNT': 'Sorry, your available fund is not enough to bet:对不起，您的最新余额不足够下注！:對不起，您的最新餘額不足夠下注！',
        'ERROR_ODDSCHANGED': 'Sorry, odds changed. Please place bet again:对不起，陪率已改变，请重新下注！:對不起，陪率已改變，請重新下注！',
        //F
        //G
        'GRAPH_STAT': 'Keno Statistic:统计表:統計表',
        'GRAPH_FRE': 'Frequency:开彩次数:開彩次數',
        //H
        //I
        //J
        //K
        'kb': 'B:大:大',
        'ks': 'S:小:小',
        'ko': 'O:单:單',
        'ke': 'E:双:雙',
        'ku': 'U:上:上',
        'kt': 'T:中:中',
        'kd': 'D:下:下',
        'ksot': 'O:单:單',
        'kset': 'E:双:雙',
        //// with s.///
        'ksots': 'S.O:星单:星單',
        'ksets': 'S.E:星双:星雙',

        'kos': 'Os:奇:奇',
        'kts': 'Ts:中:中',
        'kes': 'Es:偶:偶',
        'kbo': 'BO:大单:大單',
        'kbe': 'BE:大双:大雙',
        'kso': 'SO:小单:小單',
        'kse': 'SE:小双:小雙',
        'kg': 'Go:金:金',
        'kwd': 'Wo:木:木',
        'kwt': 'Wa:水:水',
        'kf': 'Fi:火:火',
        'kea': 'Ea:土:土',
        //// single /////
        'kgs': 'G:金:金',
        'kwds': 'W:木:木',
        'kwts': 'W:水:水',
        'kfs': 'F:火:火',
        'keas': 'E:土:土',


        'l_kdrb': 'DB:龙大:龍大',
        'l_kdrs': 'DS:龙小:龍小',
        'l_kdro': 'DO:龙单:龍單',
        'l_kdre': 'DE:龙双:龍雙',
        'l_ktib': 'TB:虎大:虎大',
        'l_ktis': 'TS:虎小:虎小',
        'l_ktio': 'TO:虎单:虎單',
        'l_ktie': 'TE:虎双:虎雙',

        'l_kdr': 'Dr:龙:龍',
        'l_kdt': 'Tie:和:和',
        'l_kti': 'Ti:虎:虎',

        'kdr': 'D:龙:龍',
        'kdt': '/:/:/',
        'kti': 'T:虎:虎',
        'kdrb': 'B:大:大',
        'kdrs': 'S:小:小',
        'kdro': 'O:单:單',
        'kdre': 'E:双:雙',
        'ktib': 'B:大:大',
        'ktis': 'S:小:小',
        'ktio': 'O:单:單',
        'ktie': 'E:双:雙',
        //L

        //M
        'MIN_TO': 'Minimum:最低投注:最低投注',
        'MAX_TO': 'Maximum:最高投注:最高投注',
        'MENU_OPENBET': 'Bet List:注单状况:注單狀況',
        'MENU_STATEMENT': 'Statement:账目:賬目',
        'MENU_RESULT': 'Result:开彩结果:開彩結果',
        'MENU_STATISTIC': 'Statistic:统计数据:統計資料',
        'MENU_GAMERULES': 'Rules:游戏规则:遊戲規則',
        'MENU_LANGUAGE': 'Language:语言:語言',

        //N
        'NEXT_DRAW': 'Next Draw:下期投注:下期投注',
        //O
        'OPENBET': 'Bet List:投注历史:投注歷史',
        'OFFICIAL': 'Official Site:官方网站:官方網站',
        //P
        'PAYOUT': 'Payout:赢取金额:贏取金額',
        'PLACE_TICKET': 'Place Bet:下注:下注',
        'PLACE_SUCCESS': 'Bet Success!:下注成功!:下注成功!',
        'PLACE_FAIL': 'Bet Fail!:下注失败!:下注失敗!',

        'PRODUCT_1': 'Australia:澳洲 Keno:澳洲 Keno',
        'PRODUCT_2': 'Beijing:北京快乐8:北京快樂8',
        'PRODUCT_3': 'Slovakia:斯洛伐克:斯洛伐克',
        'PRODUCT_4': 'Canada:加拿大:加拿大',
        'PRODUCT_5': 'West Canada:加拿大西部:加拿大西部',
        'PRODUCT_6': 'Taiwan:台湾賓果賓果:臺灣賓果賓果',
        'PRODUCT_7': 'Massac:马萨诸塞:麻塞諸塞',
        'PRODUCT_8': 'Ohio:俄亥俄:俄亥俄',
        'PRODUCT_9': 'Malta:马耳他:馬爾他',
        'PRODUCT_10': '::',
        //Q
        //R
        'RESET_TO': 'Reset:重置:重置',
        'RESULT_TIME': 'Result Time:开彩时间:開彩時間',
        'REFRESH': 'Refresh:更新:更新',

        //S
        'SESSION_HEAD': 'LOGGED OUT!:登出:登出',
        'SESSION_OUT': 'You are now logged out!:您已经被登出。:您已經被登出。',
        'SESSION_OUT2': 'You need to close this browser and re-open browser to log in again.: 请关闭您的游览器然后再次登录。:請關閉您的遊覽器然後再次登錄。',

        'STATUS_WAIT': 'Waiting Result:等待开彩:等待開彩',
        'STATUS_STOP_BET': 'Stop Betting:停止下注:停止下注',
        'STATUS_START_BET': 'Start Betting:开始下注:開始下注',
        'STATUS_RESULT': 'Open Result:公布成绩:公佈成績',
        'STATUS_PAUSE': 'Pending Result:暂停开彩:暫停開彩',
        'SWITCH_POS': 'Switch Position:转换位子:轉換位子',
        'STAT_ANALYSIS': 'Statistic Analysis:统计表:統計表',
        'STAT_BS': 'B/S:大小:大小',
        'STAT_OE': 'O/E:单双:單雙',
        'STAT_SOE': 'S.O/E:星号:星號',
        'STAT_UD': 'U/D:上下:上下',
        'STAT_FE': '5E:五行:五行',
        'STAT_DT': 'D/T:龙虎:龍虎',
        'STAT_DRBS': 'D.B/S:龙大小:龍大小',
        'STAT_DROE': 'D.O/E:龙单双:龍單雙',
        'STAT_TIBS': 'T.B/S:虎大小:虎大小',
        'STAT_TIOE': 'T.O/E:虎单双:虎單雙',



        'STAT_BS_TT': 'Big/Small:大小:大小',
        'STAT_OE_TT': 'Odd/Even:单双:單雙',
        'STAT_SOE_TT': 'Star.Odd/Even:星号:星號',
        'STAT_UD_TT': 'Up/Down:上下:上下',
        'STAT_BSOE_TT': 'Big Small /Odd Even:大小单双:大小單雙',
        'STAT_FE_TT': 'Five Element:五行:五行',
        'STAT_DT_TT': 'Dragon/Tiger:龙虎:龍虎',
        'STAT_DRBS_TT': 'Dragon.Big/Small:龙大小:龍大小',
        'STAT_DROE_TT': 'Dragon.Odd/Even:龙单双:龍單雙',
        'STAT_TIBS_TT': 'Tiger.Big/Small:虎大小:虎大小',
        'STAT_TIOE_TT': 'Tiger.Odd/Even:虎单双:虎單雙',



        'SEARCH': 'Search:搜寻:搜尋',

        'SWAP': 'Switch Position:转换:轉換',
        //T
        'TITLE_CCL': 'Refresh Available Fund:更新额度:更新額度',
        'TOTAL': 'Total:总数:總數',
        'TO': 'Stake:注额:注額',
        'TIMER': 'Timer:计时:計時',
        //U
        //V
        //W
        //X
        //Y
        //Z
        '': '::'
    }
    if (lg == "0") {

        return _lc[v].split(":")[0];
    }
    else if (lg == "1") {

        return _lc[v].split(":")[1];
    }
    else {
        return _lc[v].split(":")[2];
    }
}