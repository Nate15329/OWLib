// Instance generated by TankLibHelper.InstanceBuilder

// ReSharper disable All
namespace TankLib.STU.Types {
    [STUAttribute(0xB276BC58)]
    public class STU_B276BC58 : STUStatescriptAction {
        [STUFieldAttribute(0xBE17C500, "m_stat")]
        public teStructuredDataAssetRef<STUStat> m_stat;

        [STUFieldAttribute(0xF50C525A, "m_targets", ReaderType = typeof(EmbeddedInstanceFieldReader))]
        public STUConfigVar m_targets;
    }
}