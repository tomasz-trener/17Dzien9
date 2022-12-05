<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="P02Wstawki.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        
        <%  
            string s = "ala ma kota";
            s = s.ToUpper();

            Response.Write(s);
            %>


        <%

            

            for (int i = 0; i < 10; i++)
            {  %>
              <p> <%= "hej " + i %> </p>   
        <%  }

            %>

        <% foreach (var imie in Imiona)
            { %>
             <p><b><%= imie %></b></p>   
           <% } %>

        <div>
        </div>
    </form>
</body>
</html>
