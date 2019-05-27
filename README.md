# 바카라 게임 클라이언트

## 프로젝트 실행 환경

Jetbrain Rider

혹은

Visual Studio

## 프로토콜

Google Protocol Buffer 사용 (%PROJECT ROOT%\protobuf)

### 프로토콜 정리

#### 접속 관련

- Login Request, Response

#### 방 관련

- RoomEnter Request, Response, User List Notify, New User Broadcast

- RoomChat Request, Response, Broadcast

- RoomLeave Broadcast(소켓 OnClose 시)

#### 게임 로직 관련

- BettingRequest, Response, Broadcast

- BaccaratRoundBroadcast (게임 로직(이벤트) 단위 마다 브로드 캐스팅)

- BaccaratResultBroadcast (게임 최종 결과 브로드 캐스팅)

## 스크린샷

![Demo](https://github.com/cjwcjswo/BaccaratClient/blob/master/Resources/Demo/demo.png)
