package Config

var Adconfig map[string]AdConfig

type AdConfig struct {
	ID        int      `json:"id"`
	AdUnlock  int      `json:"AdUnlock"`
	AdType    string   `json:"AdType"`
	Push      []int		`json:"Push"`
	AdName    string	`json:"AdName"`
	AdTeam    int 		`json:"AdTeam"`
	AdCD 	  int		`json:"AdCD"`
	ADMax	  int       `json:"ADMax"`
	AdReset   int	    `json:"AdReset"`
}
