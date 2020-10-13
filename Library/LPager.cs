using System;
using System.Collections.Generic;
using System.Linq;

namespace Expedientes_Goya.Library
{
    public class LPager<T>
    {
        private int page_count = 10;
        private int page_nav_links = 3;
        private int page_actual;
        private string page_nav_back = " &laquo; Back ";
        private string page_nav_next = " Next &raquo; ";
        private string page_nav_first = " &laquo; First ";
        private string page_nav_last = " Last &raquo; ";
        private string page_nav = null;

        public object[] Pager(List<T> table, int page, int records, string area, string controller, string action, string host)
        {
            if(records > 0)
            {
                page_count = records;
            }
            if (page.Equals(0))
            {
                page_actual = 1;
            }
            else
            {
                page_actual = page;
            }

            int page_totalrecords = table.Count;
            int page_regcounter = page_totalrecords;

            if((page_totalrecords % page_count) > 0){
                page_regcounter += page_count;
            }

            int page_totalpages;
            page_totalpages = page_regcounter / page_count;

            if (page_actual != 1)
            {
                int page_url = 1;
                page_nav += "<a class='btn btn-outline-secondary' href='" + host + "/" + controller + "/" + action + "?id="
                    + page_url + "&Records=" + page_count + "&area=" + area + "'>" + page_nav_first + "</a>";

                page_url = page_actual - 1;
                page_nav += "<a class='btn btn-outline-secondary' href='" + host + "/" + controller + "/" + action + "?id="
                    + page_url + "&Records=" + page_count + "&area=" + area + "'>" + page_nav_back + "</a>";
            }

            double value = (page_nav_links / 2);
            int page_nav_interval = Convert.ToInt16(Math.Round(value));
            int page_nav_from = page_actual - page_nav_interval;
            int page_nav_to = page_actual + page_nav_interval;
            if(page_nav_from < 1)
            {
                page_nav_to -= (page_nav_from - 1);
                page_nav_from = 1;
            }
            if(page_nav_to > page_totalpages)
            {
                page_nav_from -= (page_nav_to - page_totalpages);
                page_nav_to = page_totalpages;

                if(page_nav_from < 1)
                {
                    page_nav_from = 1;
                }
            }

            for(int page_i = page_nav_from; page_i <= page_nav_to; page_i++)
            {
                if(page_i == page_actual)
                {
                    page_nav += "<span class='btn btn-outline-secondary' disabled='disabled'>" + page_i + "</span>";
                }
                else
                {
                    page_nav += "<a class='btn btn-outline-secondary' href='" + host + "/" + controller + "/" + action + "?id="
                        + page_i + "&Records=" + page_count + "&area=" + area + "'>" + page_i + "</a>";
                }
            }

            if(page_actual < page_totalpages)
            {
                int page_url = page_actual + 1;
                page_nav += "<a class='btn btn-outline-secondary' href='" + host + "/" + controller + "/" + action + "?id=" + page_url 
                    + "&Records=" + page_count + "&area=" + area +"'>" + page_nav_next + "</a>";

                page_url = page_totalpages;
                page_nav += "<a class='btn btn-outline-secondary' href='" + host + "/" + controller + "/" + action + "?id=" + page_url
                    + "&Records=" + page_count + "&area=" + area + "'>" + page_nav_last + "</a>";
            }

            int page_initial = (page_actual - 1) * page_count;
            var query = table.Skip(page_initial).Take(page_count).ToList();

            int page_from = page_initial + 1;
            int page_to = page_initial + page_count;
            if(page_to > page_totalrecords)
            {
                page_to = page_totalrecords;
            }

            string page_info = " from <b>" + page_from + "</b> to <b>" + page_to + "</b> of <b>" + page_totalrecords +
                "</b> / <b>" + page_count + "</b> records by page ";

            object[] data = { page_info, page_nav, query };
            return data;
        }

    }
}
