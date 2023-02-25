using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entity
{
    public class Title : EntityBase
    {
        /* _title_id => Attribute
           title_id => property */

        private string _title_id = "";
        public string title_id
        {
            get => _title_id;
            set
            {
                if (value != _title_id)
                {
                    if (this.State != EntityState.Added)
                        this.State = EntityState.Changed;

                    _title_id = value;
                }
            }
        }

        private string _title = "";
        public string title
        {
            get => _title;
            set
            {
                if (value != _title)
                {
                    if (this.State != EntityState.Added)
                        this.State = EntityState.Changed;

                    _title = value;
                }
            }
        }

        private string _type = "";   
        public string type
        {
            get => _type;
            set
            {
                if (value != _type)
                {
                    if (this.State != EntityState.Added)
                        this.State = EntityState.Changed;

                    _type = value;
                }
            }
        }

        private string? _pub_id = null;
        public string? pub_id
        {
            get => _pub_id;
            set
            {
                if (value != _pub_id)
                {
                    if (this.State != EntityState.Added)
                        this.State = EntityState.Changed;

                    _pub_id = value;
                }
            }
        }

        private decimal? _price = -1;
        public decimal? price
        {
            get => _price;
            set
            {
                if (value != _price)
                {
                    if (this.State != EntityState.Added)
                        this.State = EntityState.Changed;

                    _price = value;
                }
            }
        }

        private decimal? _advance = -1;
        public decimal? advance
        {
            get => _advance;
            set
            {
                if (value != _advance)
                {
                    if (this.State != EntityState.Added)
                        this.State = EntityState.Changed;

                    _advance = value;
                }
            }
        }

        private int? _royalty = -1;
        public int? royalty
        {
            get => _royalty;
            set
            {
                if (value != _royalty)
                {
                    if (this.State != EntityState.Added)
                        this.State = EntityState.Changed;

                    _royalty = value;
                }
            }
        }

        private int? _ytd_sales = -1;
        public int? ytd_sales
        {
            get => _ytd_sales;
            set
            {
                if (value != _ytd_sales)
                {
                    if (this.State != EntityState.Added)
                        this.State = EntityState.Changed;

                    _ytd_sales = value;
                }
            }
        }

        private string _notes = "";
        public string notes
        {
            get => _notes;
            set
            {
                if (value != _notes)
                {
                    if (this.State != EntityState.Added)
                        this.State = EntityState.Changed;

                    _notes = value;
                }
            }
        }

        private DateTime? _pubdate = DateTime.Today;
        public DateTime? pubdate
        {
            get => _pubdate;
            set
            {
                if (value != _pubdate)
                {
                    if (this.State != EntityState.Added)
                        this.State = EntityState.Changed;

                    _pubdate = value;
                }
            }
        }
    }
}
