// Instance generated by TankLibHelper.InstanceBuilder
using TankLib.STU.Types.Enums;

// ReSharper disable All
namespace TankLib.STU.Types {
    [STUAttribute(0xB0C4B4EF, "STULootBoxRules")]
    public class STULootBoxRules : STUInstance {
        [STUFieldAttribute(0xFA6C2B70, "m_rarityRules", ReaderType = typeof(InlineInstanceFieldReader))]
        public STULootBoxRarityRules[] m_rarityRules;

        [STUFieldAttribute(0xE056478C, "m_currencyRarityRules", ReaderType = typeof(InlineInstanceFieldReader))]
        public STULootBoxRarityRules[] m_currencyRarityRules;

        [STUFieldAttribute(0xDCEBE5E4, "m_rarityCosts", ReaderType = typeof(InlineInstanceFieldReader))]
        public STULootBoxRarityCosts[] m_rarityCosts;

        [STUFieldAttribute(0x581570BA, "m_lootboxType")]
        public Enum_26C6CD90 m_lootboxType;

        [STUFieldAttribute(0xF391EC68)]
        public int m_F391EC68;

        [STUFieldAttribute(0xCF9CD331)]
        public int m_CF9CD331;
    }
}