package Bean

type LevelData struct {
	Level            int
	Levelab          string
	Cells            string
	Specialcells     string
	Ordershapepool   string
	Randomshapespool string
	RandomshapeN     int
	Colorpool        string
	Scoretargets     string
	Passtargets      string
	Shapespecials    string
	Specialele       string
	Step             int
}

type NewLevelData struct {
	Level int
	Data  string
}

func (level NewLevelData) GetId() int {
	return level.Level
}

func (level LevelData) GetId() int {
	return level.Level
}
