public enum ActionType
{
	MoveAhead = 0,
	MoveBack = 1,
	RotateRobot = 2,
    RotateCannon = 3,
	Shoot = 4,
}

public enum EventType
{
	OnWallHit = 0,
	OnScanRobot = 1,
	OnTakeShot = 2
}

public enum ListActionType
{
	Main = 0,
	OnWallCollision = 1,
	OnScanRobot = 2
}