<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:fo="http://www.w3.org/1999/XSL/Format">
<!-- NOTE: ALWAYS REMEMBER the closing tag for the stylesheets element.  !!! -->


<xsl:template match="books">

<xsl:element name="h1"> A list of books </xsl:element>

<table width="640" border="3"  >

    <tbody>

        <tr>
            <th></th>
            <th>Author</th>
            <th>title</th>
            <th>price</th>


        </tr>

        <xsl:for-each select="book">
        <tr>
           <td> <xsl:value-of select="position()"></xsl:value-of> </td>
           <td> <xsl:value-of select="author"></xsl:value-of> </td>
           <td> <xsl:value-of select="title"></xsl:value-of> </td>
           <td> <xsl:value-of select="price"></xsl:value-of> </td>
    

        </tr>
    </xsl:for-each>
    </tbody>
</table>



    

</xsl:template>
</xsl:stylesheet>