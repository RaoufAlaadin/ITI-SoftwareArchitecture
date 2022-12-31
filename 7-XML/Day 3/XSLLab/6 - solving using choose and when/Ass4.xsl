<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:fo="http://www.w3.org/1999/XSL/Format">
<!-- NOTE: ALWAYS REMEMBER the closing tag for the stylesheets element.  !!! -->


<xsl:template match="CATALOG">

<xsl:element name="h1"> My CD Collection </xsl:element>

<table border="1" >

    <tbody>

        <tr bgcolor="#9acd32">
            <th></th>
            <th>CD-title</th>
            <th>Artist</th>
            <th>PRICE</th>

        </tr>

        <xsl:for-each select="CD">
            <xsl:choose>
                <xsl:when test="PRICE>10">
                    <tr style="background-color:red">

                        <td> <xsl:value-of select="position()"></xsl:value-of> </td>
                        <td> <xsl:value-of select="TITLE"></xsl:value-of> </td>
                        <td> <xsl:value-of select="ARTIST"></xsl:value-of> </td>
                        <td> <xsl:value-of select="PRICE"></xsl:value-of> </td>
                        
                     </tr>

                    <!-- RED-->
                </xsl:when>
                <xsl:otherwise>

                <tr style="background-color:green">

                    <td> <xsl:value-of select="position()"></xsl:value-of> </td>
                    <td> <xsl:value-of select="TITLE"></xsl:value-of> </td>
                    <td> <xsl:value-of select="ARTIST"></xsl:value-of> </td>
                    <td> <xsl:value-of select="PRICE"></xsl:value-of> </td>
                    
                 </tr>


                </xsl:otherwise>
            </xsl:choose>
        
    </xsl:for-each>
    </tbody>
</table>



    

</xsl:template>
</xsl:stylesheet>