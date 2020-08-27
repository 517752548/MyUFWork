using Newtonsoft.Json;

public class AppflyerPurcherData
{
    [JsonProperty("product_id")]
    public string product_id { get; set; }

    [JsonProperty("quantity")]
    public string quantity { get; set; }

    [JsonProperty("transaction_id")]
    public string transaction_id { get; set; }

    [JsonProperty("purchase_date_ms")]
    public string purchase_date_ms { get; set; }

    [JsonProperty("is_trial_period")]
    public string is_trial_period { get; set; }

    [JsonProperty("original_transaction_id")]
    public string original_transaction_id { get; set; }

    public AppflyerPurcherData()
    {
        this.product_id = "-1";
        this.quantity = "-1";
        this.transaction_id = "-1";
        this.purchase_date_ms = "-1";
        this.is_trial_period = "-1";
        this.original_transaction_id = "-1";
    }
}