using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Entity;
using BLL.EntityList;
using DAL;

namespace BLL.EntityManager
{
    public class TitleManger
    {
        static DBManager manager = new();

        public static TitleList SelectAllTitles()
        {
            try
            {
                return DataTableToTitleList(manager.ExecuteDataTable("SelectAllTitles"));
            }
            catch
            {
                return new TitleList();
            }
        }

        /* Note: Theoratically you don't need to do any validation here,
         because all the data in each Title object, would have not been able
        to be stored in the object in the first place if it causes an error.
        
         This is due to the checks we have on each property in the
         Title.cs
        */
        public void AddTitle(Title title)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@title_id", title.title_id);
            parameters.Add("@title", title.title);
            parameters.Add("@type", title.type);
            parameters.Add("@pub_id", title.pub_id);
            parameters.Add("@price", title.price);
            parameters.Add("@advance", title.advance);
            parameters.Add("@royalty", title.royalty);
            parameters.Add("@ytd_sales", title.ytd_sales);
            parameters.Add("@notes", title.notes);
            parameters.Add("@pubdate", title.pubdate);
            manager.ExecuteNonQuery("usp_add_title", parameters);
        }

        public void UpdateTitle(Title title)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@title_id", title.title_id);
            parameters.Add("@title", title.title);
            parameters.Add("@type", title.type);
            parameters.Add("@pub_id", title.pub_id);
            parameters.Add("@price", title.price);
            parameters.Add("@advance", title.advance);
            parameters.Add("@royalty", title.royalty);
            parameters.Add("@ytd_sales", title.ytd_sales);
            parameters.Add("@notes", title.notes);
            parameters.Add("@pubdate", title.pubdate);

            // Call DatabaseManager method with stored procedure name and parameters
            manager.ExecuteNonQuery("usp_update_title", parameters);
        }

        public void DeleteTitle(string titleId)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@title_id", titleId);

            // Call DatabaseManager method with stored procedure name and parameters
            manager.ExecuteNonQuery("usp_delete_title", parameters);
        }

        #region Stored procedure Queries

        /* // Add
         *
                     CREATE PROCEDURE [dbo].[usp_add_title]
            @title_id nvarchar(6),
            @title nvarchar(80),
            @type nvarchar(12),
            @pub_id nchar(4),
            @price money,
            @advance money,
            @royalty int,
            @ytd_sales int,
            @notes ntext,
            @pubdate datetime
            AS
            BEGIN
            INSERT INTO titles (title_id, title, type, pub_id, price, advance, royalty, ytd_sales, notes, pubdate)
            VALUES (@title_id, @title, @type, @pub_id, @price, @advance, @royalty, @ytd_sales, @notes, @pubdate)
            END

        // Update


                    CREATE PROCEDURE [dbo].[usp_update_title]
                @title_id nvarchar(6),
                @title nvarchar(80),
                @type nvarchar(12),
                @pub_id nchar(4),
                @price money,
                @advance money,
                @royalty int,
                @ytd_sales int,
                @notes ntext,
                @pubdate datetime
            AS
            BEGIN
                UPDATE titles
                SET title = @title,
                    type = @type,
                    pub_id = @pub_id,
                    price = @price,
                    advance = @advance,
                    royalty = @royalty,
                    ytd_sales = @ytd_sales,
                    notes = @notes,
                    pubdate = @pubdate
                WHERE title_id = @title_id
            END

        // Delete

                CREATE PROCEDURE [dbo].[usp_delete_title]
            @title_id nvarchar(6)
        AS
        BEGIN
            DELETE FROM titles
            WHERE title_id = @title_id
        END


         */

        #endregion

        #region Mapping

        internal static TitleList DataTableToTitleList(DataTable dt)
        {
            TitleList titleList = new();
            try
            {
                foreach (DataRow row in dt.Rows)
                    titleList.Add(DataRowToTitle(row));
            }
            catch { }
            return titleList;
        }

        internal static Title DataRowToTitle(DataRow Dr)
        {
            // each object has 10 attributes.
            Title title = new();
            try
            {
                // 1- title_ID
                title.title_id = Dr["title_id"].ToString() ?? "TC7799";
                // 2- title ( it's name)

                title.title = Dr["title"].ToString() ?? "Macaronee";

                // 3- title

                title.type = Dr["type"].ToString() ?? "business";

                // 4- title

                title.pub_id = Dr["pub_id"].ToString() ?? "0877";

                // 5- title


                if (decimal.TryParse(Dr["price"]?.ToString() ?? "20555", out decimal tempPrice))
                    title.price = tempPrice;

                // 6- title

                if (decimal.TryParse(Dr["advance"]?.ToString() ?? "5555", out decimal tempAdvance))
                    title.advance = tempAdvance;

                // 7- title


                if (int.TryParse(Dr["royalty"]?.ToString() ?? "30", out int tempRoyalty))
                    title.royalty = tempRoyalty;

                // 8- title


                if (int.TryParse(Dr["ytd_sales"]?.ToString() ?? "3355", out int tempYtdSales))
                    title.ytd_sales = tempYtdSales;

                // 9- title


                title.notes = Dr["notes"].ToString() ?? " NEWW This is a test title";

                // 10- title

                if (
                    DateTime.TryParse(
                        Dr["pubdate"]?.ToString() ?? "5/5/2020",
                        out DateTime tempPubDate
                    )
                )
                    title.pubdate = tempPubDate;

                title.State = EntityState.UnChanged;
            }
            catch
            {
                ///
            }
            return title;
        }
        #endregion
    }
}
