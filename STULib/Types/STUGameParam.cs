// File auto generated by STUHashTool

using STULib.Types.Dump;
using STULib.Types.Enums;
using STULib.Types.Generic;

namespace STULib.Types {
    [STU(0x074EDCB9)]
    public class STUGameParam : Common.STUInstance {
        [STUField(0xAA76FAD1)]
        public Common.STUGUID Name;

        [STUField(0x7DF418A5)]
        public Common.STUGUID Name2;

        [STUField(0x3E783677)]
        public Common.STUGUID Virtual01C;  // STU_9CADF2EC

        [STUField(0x7E3ED979)]
        public Common.STUGUID[] m_7E3ED979;  // STU_0A29DB0D

        [STUField(0x34993B2E)]
        public Common.STUGUID[] m_34993B2E;  // STU_0A29DB0D

        [STUField(0x07DD813E, EmbeddedInstance = true)]
        public STUGameParamBaseOptions Options;

        [STUField(0x65184E78, EmbeddedInstance = true)]
        public STU_96788737 m_65184E78;

        [STUField(0x2C54AEAF, "m_category")]
        public STUEnum_F2F62E3D Category;

        [STUField(0x37D4F9CD)]
        public int UnknownInt;
    }
}
