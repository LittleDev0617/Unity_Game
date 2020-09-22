# 개발노트
## 9/18 - 전체 회의
유니티 에셋스토어에서 제공해주는 무료 에셋 사용하기로 함.
주인공 캐릭터는 wasd 로 움직이며, 마우스로 검을 회전시킬 수 있다.

## 9/21  - 11pm ~ 1:35 am
기본적인 Player UI, Story_Dialogue UI, Esc UI, Cursor UI 등을 구현하였다.

플레이어 IDLE animation 구현.(기존 에셋에 없어서 직접 만듦 -> 기존 Script와 연동)

상호작용 가능한 오브젝트들에게 DefaultObject Script를 넣음.
DefaultObject 는 name, description의 public 멤버변수와 OnMouseOver, ~Exit,~Enter 등과 같이 마우스가 들어왔을때
색을 어둡게하고, 오른쪽 하단에 그 이름과 그림이 뜨게끔 함.(Player Script의 Target)

상호작용 가능한 오브젝트 위로 마우스를 올리면, 그 오브젝트의 설명이 검은 배경 위에 뜨게끔 함.
이는 마우스가 움직일때 따라간다.

Esc를 통한 Top UI 제거 기능 구현

Player UI 에서 캐릭터의 모습을 보여줘야하는데, 이를 Camera를 추가한뒤, Target Texture를 따로 뺴내서, 이 texture를 raw Image 에다가 넣어서 구현했다.
