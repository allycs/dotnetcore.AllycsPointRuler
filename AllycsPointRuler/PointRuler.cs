using System;

namespace AllycsPointRuler
{
    /// <summary>
    /// 所有int类型参数0代表不计入
    /// IN积分规则：（old为上一步生成的point"?"为PlusOrMinus的方式；point、amount、multiple为非负数）
    /// point非0；amount为0；multiple非0。则[old？（point*multiple）]
    /// point非0；amount为0：multiple为0。则[old？point]
    /// point非0；amount非0；multiple为0。则[old？（满足amount的point）]
    /// point非0；amount非0；multiple非0。则[old？(满足amount的point*multiple)]
    ///
    /// point为0；amount非0；multiple非0。则[old]
    /// point为0；amount非0；multiple为0。则[old]
    /// point为0；amount为0；multiple非0。则[old*multiple]
    /// point为0；amount为0；multiple为0。则[old]
    ///
    /// OUT积分规则：（old为上一步等号左侧的生成的amount"?"为PlusOrMinus的方式（产生的amount同，point计算均正数）；point、amount、multiple为非负数）
    ///
    /// amount非0；point为0；multiple非0。
    ///     则amount=[old-（amount*multiple）]；point=[old]
    /// amount非0；point为0：multiple为0。
    ///     则amount=[old-amount]；point=[old]
    /// amount非0；point非0；multiple为0。
    ///     则amount=[old-（满足point的amount）];point=[old?(point*满足point的amount)]
    /// amount非0；point非0；multiple非0。
    ///     则amount=[old-(满足point的amount*multiple)];point=[old?(point*满足point的amount*multiple)]
    ///
    /// amount为0；point非0；multiple非0。
    ///     则amount=[old]；point=[old?(point*multiple)]
    /// amount为0；point非0；multiple为0。
    ///     则amount=[old];point = [old?point]
    /// amount为0；point为0；multiple非0。
    ///     则amount=[old]；point=[old]
    /// amount为0；point为0；multiple为0。
    ///     则amount=[old]；point=[old]
    /// </summary>
    public class PointRuler
    {
        /// <summary>
        /// 是否遵循多规则（默认多规则）
        /// </summary>
        public bool IsOnly { get; set; } = true;

        /// <summary>
        /// 权重值（单规则以权重最高为准；多规则倒叙计算）
        /// </summary>
        public int Weight { get; set; } = 0;

        /// <summary>
        /// 触发金额（单位分）
        /// </summary>
        public Int64 Amount { get; set; } = 0;

        /// <summary>
        /// 获得积分（可负）
        /// </summary>
        public Int64 Point { get; set; } = 0;

        /// <summary>
        /// 触发多倍数(默认1倍)
        /// </summary>
        public int Multiple { get; set; } = 1;

        /// <summary>
        /// ture：plus
        /// </summary>
        public bool PlusOrMinus { get; set; } = true;

        /// <summary>
        /// 本条规则描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 当抵扣额大于被抵扣额是否抵扣(仅out中使用)
        /// </summary>
        public bool Deduction { get; set; } = true;
    }
}