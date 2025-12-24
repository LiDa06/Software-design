namespace PaymentsService.Models;
public class Account
{
    public Guid UserId { get; set; }
    public long Balance { get; set; }
    public byte[] RowVersion { get; set; } = default!;
}
