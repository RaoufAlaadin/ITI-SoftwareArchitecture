/* Structs,Enums,Classes are internal by default, that's why they can be accessed if we enclose them with a name space
 
    but the members inside of them are private by default !!!

    that's why need to make the enums inside as public or internal

    internal means ===> they can be accessed from this project only, if you want to link other projects
                        then you have to add reference between the 2 projects.
 */

namespace CompanySystem
{
    struct Enums
    {
        /* here I can set the Enum to being internal or public depending on the level of encapsulation I want. */
        [Flags]
        public enum SecurityLevels : byte
        {
            Read = 1,
            Write = 2,
            Execute = 4,
            Delete = 8,

            guest = Read,
            developer = Read | Write,
            secretary = Write,
            DBA = Read | Write | Execute,
            securityOfficer = Read | Write | Execute | Delete
        }

        public enum Gender : byte
        {
            M,
            F
        }
    }
}
