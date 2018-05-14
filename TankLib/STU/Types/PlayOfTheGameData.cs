// Instance generated by TankLibHelper.InstanceBuilder
using TankLib.STU.Types.Enums;

// ReSharper disable All
namespace TankLib.STU.Types {
    [STUAttribute(0x66F7F227, "PlayOfTheGameData")]
    public class PlayOfTheGameData : STUInstance {
        [STUFieldAttribute(0x2EB5792F)]
        public teStructuredDataAssetRef<STU_C0368123> m_2EB5792F;

        [STUFieldAttribute(0x7108ECE0, "m_id", ReaderType = typeof(EmbeddedInstanceFieldReader))]
        public STUConfigVar m_id;

        [STUFieldAttribute(0x5180E750, "m_value", ReaderType = typeof(EmbeddedInstanceFieldReader))]
        public STUConfigVar m_value;

        [STUFieldAttribute(0xF50C525A, "m_targets", ReaderType = typeof(EmbeddedInstanceFieldReader))]
        public STUConfigVar m_targets;

        [STUFieldAttribute(0x0E27C815, "m_description", ReaderType = typeof(EmbeddedInstanceFieldReader))]
        public STUConfigVar m_description;

        [STUFieldAttribute(0x475005D5)]
        public Enum_17FFE96F m_475005D5;
    }
}