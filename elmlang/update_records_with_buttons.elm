import Html exposing (div, button, text)
import Html.Events exposing (onClick)
import StartApp.Simple as StartApp

main =
  StartApp.start { model = { x =0, y = 0 }, view = view, update = update }


view address model =
  div []
    [ div[][
          button [ onClick address Left ] [ text "←" ] , 
          button [ onClick address Right ] [ text "→" ],
          button [ onClick address Down ] [ text "↓" ],
          button [ onClick address Up ] [ text "↑" ] 
       ]
    , div [] [ text (toString model) ]
    ]

type Direction = Up | Down | Left | Right

update action model =
  case action of
    Up ->  { model | y = model.y + 1 }
    Down ->  { model | y = model.y - 1 }
    Right ->  { model | x = model.x + 1 }
    Left ->  { model | x = model.x - 1 }