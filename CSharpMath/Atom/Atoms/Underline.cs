namespace CSharpMath.Atom.Atoms {
  /// <summary>An underlined atom</summary>
  public class Underline : MathAtom, IMathListContainer1 {
    public MathList InnerList { get; }
    public Underline(MathList innerList) : base() =>
      InnerList = innerList;
    public new Underline Clone(bool finalize) => (Underline)base.Clone(finalize);
    protected override MathAtom CloneInside(bool finalize) =>
      new Underline(InnerList.Clone(finalize));
    public override bool ScriptsAllowed => true;
    public override string DebugString =>
      new System.Text.StringBuilder(@"\underline")
      .AppendInBracesOrLiteralNull(InnerList.DebugString)
      .ToString();
    public bool EqualsUnderline(Underline other) =>
      EqualsAtom(other) && InnerList.EqualsList(other.InnerList);
    public override bool Equals(object obj) =>
      obj is Underline u ? EqualsUnderline(u) : false;
    public override int GetHashCode() => (base.GetHashCode(), InnerList).GetHashCode();
  }
}