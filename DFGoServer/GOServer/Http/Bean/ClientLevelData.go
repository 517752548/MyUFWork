package Bean

type ClientLevelData struct {
	Level            int
	Levelab          string
	Cells            []NormalCellInfo
	OrderShapePool   []int
	RandomShapesPool []int
	RandomShapeN     int
	ColorPool        []ColorPool
	ScoreTargets     []int
	PassTargets      []TargetPool
	SpecialEle []SpecialCellInfo
	ShapeSpecials []ShapeSpecialsData
	Step int
}
type NormalCellInfo struct {
	X int
	Y int
	Group int
}
type CellInfo struct {
	X int
	Y int
	Para []int
}

type ColorPool struct {
	Id int
	Number int
}

type TargetPool struct {
	Id int
	Number int
	Para []int
}
type SpecialCellInfo struct {
	X int
	Y int
	Id int
	Para []int
}

type PassLevelInfo struct {
	score1 int
	score2 int
	score3 int
}

type ShapeSpecialsData struct {
	Id int
	MaxCurrent int
	MinCurrent int
	MaxStep int
	MinStep int
	Total int
	Step int
	Para []int
}
