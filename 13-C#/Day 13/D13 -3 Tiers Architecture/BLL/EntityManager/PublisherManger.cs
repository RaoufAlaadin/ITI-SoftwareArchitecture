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
    public class PublisherManger
    {
        static DBManager manager = new();

        public static PublisherList SelectAllPublishers()
        {
            try
            {
                return DataTableToPublisherList(manager.ExecuteDataTable("SelectAllPublishers"));
            }
            catch
            {
                return new PublisherList();
            }
        }

        /* Note: Theoratically you don't need to do any validation here,
         because all the data in each Title object, would have not been able
        to be stored in the object in the first place if it causes an error.
        
         This is due to the checks we have on each property in the
         Title.cs
        */




    #region Mapping

        internal static PublisherList DataTableToPublisherList(DataTable dt)
        {
            PublisherList publisherList = new();
            try
            {
                foreach (DataRow row in dt.Rows)
                    publisherList.Add(DataRowToPublisher(row));
            }
            catch { }
            return publisherList;
        }

        internal static Publisher DataRowToPublisher(DataRow Dr)
        {
            // each object has 5 attributes.
            Publisher publisher = new();
            try
            {
                // 1- pub_id
                publisher.pub_id = Dr["pub_id"].ToString() ?? "0877";

                // 2- pup_name
                publisher.pub_name= Dr["pub_name"].ToString() ?? "ABC Publishers";

                // 3- city
                publisher.city = Dr["city"].ToString() ?? "New York";

                // 4- state
                publisher.state = Dr["state"].ToString() ?? "NY";

                // 5- country
                publisher.country = Dr["country"].ToString() ?? "USA";

                publisher.State = EntityState.UnChanged;
            }
            catch
            {
                ///
            }
            return publisher;
        }
    #endregion
    }
}
