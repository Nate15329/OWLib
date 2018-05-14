// Instance generated by TankLibHelper.InstanceBuilder

// ReSharper disable All
namespace TankLib.STU.Types {
    [STUAttribute(0x82C74C1D)]
    public class STU_82C74C1D : STUInstance {
        [STUFieldAttribute(0x5922C415, ReaderType = typeof(InlineInstanceFieldReader))]
        public STU_6F8A55BB m_5922C415;

        [STUFieldAttribute(0x5D96917B, ReaderType = typeof(EmbeddedInstanceFieldReader))]
        public STU_A1DF5CE6[] m_5D96917B;

        [STUFieldAttribute(0x7B5125B3, "m_states")]
        public teStructuredDataAssetRef<STUEffectTemplateState>[] m_states;

        [STUFieldAttribute(0x6EFE78D0, ReaderType = typeof(EmbeddedInstanceFieldReader))]
        public STU_82C74C1D[] m_6EFE78D0;

        [STUFieldAttribute(0x0AB6F7CD)]
        public byte m_0AB6F7CD;
    }
}