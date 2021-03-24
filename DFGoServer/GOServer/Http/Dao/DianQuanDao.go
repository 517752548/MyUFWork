package Dao



type DianQuanDao struct {

	AccountID         string `json:"AccountID"`
}


//初始化的方法  必须调用
func (psd *DianQuanDao)Init(accountID string) *DianQuanDao {
	psd.AccountID = accountID
	return psd
}