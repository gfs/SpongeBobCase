module Main exposing (bobCase)

import Browser
import Html exposing (Html, Attribute, div, input, text)
import Html.Attributes exposing (..)
import Html.Events exposing (onInput)
import Html exposing (pre)
import Html exposing (br)

-- MAIN

main =
  Browser.sandbox { init = init, update = update, view = view }

-- MODEL

type alias Model =
  { content : String
  }


init : Model
init =
  { content = "" }


-- LOGIC
bobCase:String -> String
bobCase input =
  input
  |> String.toList
  |> List.indexedMap(\ i x -> if ((i |> modBy 2) == 0) then x |> Char.toUpper else x |> Char.toLower)
  |> String.fromList

-- UPDATE

type Msg
  = Change String


update : Msg -> Model -> Model
update msg model =
  case msg of
    Change newContent ->
      { model | content = newContent }

-- OUR HERO
bobFrame : String
bobFrame = """
*
      *
 ----//-------
 \\..C/--..--/ \\   `A
  (@ )  ( @) \\  \\// |w
   \\          \\  \\---/
    HGGGGGGG    \\    /`
    V `---------`--'
        <<    <<
       ###   ###
"""

-- VIEW


view : Model -> Html Msg
view model =
  div []
    [ input [ placeholder "Text to SpOnGeBoB", value model.content, onInput Change ] []
    , br [] []
    , pre [] [ text (bobCase model.content) ]
    , pre [] [ text (bobFrame) ]
    ]