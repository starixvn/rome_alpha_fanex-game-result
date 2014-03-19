<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KenoSmart.aspx.cs" Inherits="Fanex.Game.Keno.Test.KenoSmart" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <input type="button" value="Keno Smart" onclick="viewKenoSmart()"/>
    </div>
    </form>
</body>
<script type="text/javascript" language="javascript">
    
    function viewKenoSmart() {
        window.open("/keno/game/keno/kenoresult/resultdetail?date=20140311&language=en&customerId=1373389");
    }
</script>
</html>
