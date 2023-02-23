using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entity
{
    public class Publisher : EntityBase
    {
        /* _title_id => Attribute
           title_id => property */

        private string _pub_id;
        public string pub_id
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


        private string _pub_name;
        public string pub_name
        {
            get => _pub_name;
            set
            {
                if (value != _pub_name)
                {
                    if (this.State != EntityState.Added)
                        this.State = EntityState.Changed;

                    _pub_name = value;
                }
            }
        }


        private string _city;
        public string city
        {
            get => _city;
            set
            {
                if (value != _city)
                {
                    if (this.State != EntityState.Added)
                        this.State = EntityState.Changed;

                    _city = value;
                }
            }
        }


        private string _state;
        public string state
        {
            get => _state;
            set
            {
                if (value != _state)
                {
                    if (this.State != EntityState.Added)
                        this.State = EntityState.Changed;

                    _state = value;
                }
            }
        }



        private string _country;
        public string country
        {
            get => _country;
            set
            {
                if (value != _country)
                {
                    if (this.State != EntityState.Added)
                        this.State = EntityState.Changed;

                    _country = value;
                }
            }
        }

    }
}
