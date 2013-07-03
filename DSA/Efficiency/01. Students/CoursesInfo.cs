// -----------------------------------------------------------------------
// <copyright file="CoursesInfo.cs" company="Telerik">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Students
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Sorted dictionary, holding info about students and courses. The key is the course name.
    /// The value is sorted set of students names.
    /// </summary>
    public class CoursesInfo
    {
        public CoursesInfo()
        {
            this.Entries = new SortedDictionary<string, SortedSet<string>>();
        }

        public CoursesInfo(string key)
            : this()
        {
            SortedSet<string> names = new SortedSet<string>(new ByLastname());
            this.Entries.Add(key, names);
        }

        public CoursesInfo(string key, string name)
            : this(key)
        {
            this.Entries[key].Add(name); 
        }

        public SortedDictionary<string, SortedSet<string>> Entries { get; set; }

        public void AddCourseEntry(string key, string name)
        {
            if (this.Entries.ContainsKey(key))
            {
                this.Entries[key].Add(name);
            }
            else 
            {
                SortedSet<string> names = new SortedSet<string>(new ByLastname());
                names.Add(name);
                this.Entries.Add(key, names);                
            }
        }

        public SortedSet<string> GetNames(string key)
        {
            return this.Entries[key];
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var entry in this.Entries)
            {
                sb.AppendFormat("{0}: {1}\r\n", entry.Key, string.Join(", ", entry.Value));
            }

            sb.Remove(sb.Length - 2, 2);
            return sb.ToString();
        }

        // Class Comparer by last name first, case insensitive.
        private class ByLastname : IComparer<string>
        {
            private string xLastName, yLastName;

            private CaseInsensitiveComparer caseiComp = new CaseInsensitiveComparer();

            public int Compare(string x, string y)
            {
                // Parse the last name from the name string. 
                this.xLastName = x.Substring(x.LastIndexOf(" ") + 1);
                this.yLastName = y.Substring(y.LastIndexOf(" ") + 1);

                // Compare the last names.  
                int compareLastNames = this.caseiComp.Compare(this.xLastName, this.yLastName);
                if (compareLastNames != 0)
                {
                    return compareLastNames;
                }
                else
                {
                    // The last names are the same,  
                    // so compare by the first names.  
                    return this.caseiComp.Compare(x, y);
                }
            }
        }
    }
}
