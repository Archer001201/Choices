# Choices
IAT 222 Final Project

Are you good at making game?

待完成：
1. 玩家和玩家对话
2. 玩家选择
3. 玩家勇气条

bug解决方案：
1. bug描述： 
a)两个玩家在房间中的时候，npc对话提示显示混乱（逻辑有问题)
b)npc对话内容显示混乱（逻辑问题）
解决方案：
a)区分两个玩家的canTalk，当至少有一个canTalk == true的时候，提示激活
b)把空格键操作放在playerController里面，当空格键被按下时，给dialogue controller返回一个bool值
