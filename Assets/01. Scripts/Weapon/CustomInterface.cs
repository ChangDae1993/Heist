public interface IAttackAble
{
    public void Attack(IHitAble hit);
}

public interface IHitAble
{
    float Hp {  get; set; }
}
