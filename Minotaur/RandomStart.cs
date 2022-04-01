
using System;

class RandomStartPoint {
public int dimension;
public int player_start;
public int sword_pos;

public char[,] theMaze;

public RandomStartPoint() {
dimension=15;

theMaze=new char[dimension,dimension];
player_start = dimension/2;
sword_pos = dimension/2;
for(int i=0;i<dimension;i++) {
for(int j=0;j<dimension;j++) {
theMaze[i,j]=' ';
}
}

initializeMaze();

}

private void initializeMaze() {
Random myRand=new Random();

//Put in random walls
for(int i=0;i<dimension;i++) {
for(int j=0; j<dimension;j++) {
if(myRand.Next(10)>=7) {
theMaze[i,j]='X';
}
}
}

//Pick a random goal
int goal_x=myRand.Next(dimension-1);
int goal_y=myRand.Next(dimension-1);
theMaze[goal_x,goal_y]='C';

//Place the starting position
theMaze[player_start,sword_pos]='M';
}
}