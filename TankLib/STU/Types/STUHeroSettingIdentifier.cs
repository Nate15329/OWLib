// Instance generated by TankLibHelper.InstanceBuilder

// ReSharper disable All
namespace TankLib.STU.Types {
    [STUAttribute(0x0B10ED5A, "STUHeroSettingIdentifier")]
    public class STUHeroSettingIdentifier : STUHeroSettingBase {
        [STUFieldAttribute(0xB9114C96, "m_default")]
        public teStructuredDataAssetRef<STUIdentifier> m_default;

        [STUFieldAttribute(0x77B7FF8C, "m_entries", ReaderType = typeof(EmbeddedInstanceFieldReader))]
        public STU_8245A944[] m_entries;
    }
}