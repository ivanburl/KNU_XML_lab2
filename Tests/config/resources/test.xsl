<?xml version="1.0" encoding="utf-8" ?> 
<xsl:stylesheet version="1.0" 
                xmlns:xsl = "http://www.w3.org/1999/XSL/Transform"> 
    
    <xsl:output method="html"/>
    
    <xsl:template match="/"> 
        <html> 
            <body>
                <table border="1">
                    <TR>
                        <th>CompanyName</th>
                        <th>ContactName</th>
                        <th>ContactTitle</th>
                    </TR>
                    
                    <xsl:for-each select="Root/Customer">
                        <tr>
                            <td>
                                <xsl:value-of select="@CompanyName"/>    
                            </td>
                            
                            <td>
                                <xsl:value-of select="@ContactName"/>
                            </td>
                            
                            <td>
                                <xsl:value-of select="@ContactTitle"/>
                            </td>
                        </tr>
                    </xsl:for-each>
                </table>
             </body>
        </html>
    </xsl:template>
</xsl:stylesheet>