// Instance generated by TankLibHelper.InstanceBuilder

// ReSharper disable All
namespace TankLib.STU.Types {
    [STUAttribute(0x81D63677, "STUVoiceConversation")]
    public class STUVoiceConversation : STUInstance {
        [STUFieldAttribute(0x98B129EB, "m_stimulus")]
        public teStructuredDataAssetRef<STUVoiceStimulus> m_stimulus;

        [STUFieldAttribute(0xE1ED0A9D, "m_voiceConversationLine", ReaderType = typeof(InlineInstanceFieldReader))]
        public STUVoiceConversationLine[] m_voiceConversationLine;

        [STUFieldAttribute(0xB9452DF9, ReaderType = typeof(EmbeddedInstanceFieldReader))]
        public STU_83066946 m_B9452DF9;

        [STUFieldAttribute(0x4D5E07BF, "m_weight")]
        public float m_weight;
    }
}