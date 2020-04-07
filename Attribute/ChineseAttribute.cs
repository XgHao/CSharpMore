using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributeDemo
{
    public sealed class ChineseAttribute : Attribute
    {
        public string Chinese { get; set; }

        public ChineseAttribute(string _chinese = "未汉化")
        {
            Chinese = _chinese;
        }
    }
}
