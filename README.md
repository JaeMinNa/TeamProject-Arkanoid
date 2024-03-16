<p align="center">
  <img src="https://github.com/psw1305/TeamProject-Arkanoid/assets/6329345/76e3d078-0fdb-4051-99f9-13443a1b6453" width="100%" alt="타이틀"/>
</p>

## 🖥️ Arkanoid 24
### [게임 플레이 itch.io](https://shshck5.itch.io/arkanoid24)

+ 벽돌깨기 게임의 대명사 'Arkanoid'. 2024년, 사이버펑크로 돌아오다!
+ 클래식 : 10개의 level, 점점 단단해지는 벽돌!
+ 무한 모드 : 하트는 단 3개! 어디까지 깰 수 있을까?
+ 타임 어택 : 가장 빠르게 레벨을 클리어해보세요!
+ 대전 모드 : 키보드 하나로 둘이서 겨루는 재미!
<br/>

## 📽️ 프로젝트 소개
 - 게임 이름 : Arkanoid 24
 - 플랫폼 : PC
 - 장르 : 2D 아케이드
 - 개발 기간 : 23.11.30 ~ 23.12.07
<br/>

## ⚙️ Environment

- `Unity 2022.3.2`
- **IDE** : Visual Studio 2019, 2022, MonoDevelop
- **VCS** : Git (GitHub Desktop)
- **Envrionment** : PC `only`
- **Resolution** :	1920 x 1080 `FHD`
<br/>

## 👤Collaborator - Team Intro
- 팀장  `송희성` - 리팩터링 / 사용자 입력 / 플레이어(Paddle) / 공(Ball) / 멀티 플레이어 (로컬)
- 팀원1 `박상원` - 전체적인 게임 흐름, 로직 (코어) / UI디자인 및 리소스 제공 / 게임매니저 / 코드 리뷰
- 팀원2 `구도현` - 벽(Brick) 레벨 구성 / 스프라이트 리소스 / 멀티 플레이어 (로컬) / 상호작용(Interact)
- 팀원3 `유건희` - UI디자인 및 데이터 바인딩 / 프리팹 및 리소스 / 게임 컨셉 / 랭킹 및 플레이어 제어
- 팀원4 `고민수` - 아이템 디자인 / 아이템 스킬 구현 / 스킬 매니저 / 코드 분기 통합 / 트러블 슈팅
- 팀원5 `나재민` - 아이템 디자인 / 아이템 스킬 구현 / UI디자인 (설정) / 상호작용(Interact)
<br/>

## ▶️ 게임 스크린샷

<p align="center">
  <img src="https://github.com/psw1305/TeamProject-Arkanoid/assets/6329345/facd7cc8-6496-4077-b791-d66f1c045b8f" width="49%"/>
  <img src="https://github.com/psw1305/TeamProject-Arkanoid/assets/6329345/b00650d4-b475-4b98-bd56-546cfe9043ee" width="49%"/>
</p>
<p align="center">
  <img src="https://github.com/psw1305/TeamProject-Arkanoid/assets/6329345/d81b35e8-f8cd-4fc3-9487-05ebab0604cb" width="49%"/>
  <img src="https://github.com/psw1305/TeamProject-Arkanoid/assets/6329345/85f6eec0-2185-4eb7-a40e-da3b0723ea8d" width="49%"/>
  </p>
<p align="center">
  <img src="https://github.com/psw1305/TeamProject-Arkanoid/assets/6329345/40184cc1-56d9-418f-ac51-3bab6909fe14" width="49%"/>
  <img src="https://github.com/psw1305/TeamProject-Arkanoid/assets/6329345/d53fc929-3b17-4872-92d0-c2bac834b4ae" width="49%"/>
</p>
<p align="center">
  <img src="https://github.com/psw1305/TeamProject-Arkanoid/assets/6329345/d53fc929-3b17-4872-92d0-c2bac834b4ae" width="49%"/>
  <img src="https://github.com/psw1305/TeamProject-Arkanoid/assets/6329345/facd7cc8-6496-4077-b791-d66f1c045b8f" width="49%"/>
</p>
<br/>

## ✏️ 구현 기능

### 1. 게임 BGM, 효과음 조절 기능 구현
<img src="https://github.com/psw1305/TeamProject-Arkanoid/assets/6329345/cbbc8078-e671-49af-9506-1bd1efe6649b" width="50%"/>

- Slider의 value 값으로 AudioMixer 조절
```C#
public void AudioControl()
{
    float sound = audioSlider.value;

    if(sound == -40f)	// -40일 때, 음악을 꺼줌
    {
        audioMixer.SetFloat("Master", -80f);
    }
    else
    {
        audioMixer.SetFloat("Master", sound);
    }
}
```
<br/>

### 2. ItemDisruption 아이템 구현
<img src="https://github.com/psw1305/TeamProject-Arkanoid/assets/6329345/864af289-0ab7-47d4-800f-f44c676aa1ce" width="50%"/>

- 2개의 추가 Ball 생성 및 Vector 값 변경으로 구현
```C#
public void Disruption()
{
    var ball = Managers.Game.CurrentBalls[0];
    Rigidbody2D BallRb = ball.GetComponent<Rigidbody2D>();
    Vector2 BallVec = BallRb.velocity;

    InstantiateBall(ball, BallRb, BallVec, false);
    InstantiateBall(ball, BallRb, BallVec, true);
}
```
<br/>
