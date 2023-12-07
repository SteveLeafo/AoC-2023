Imports System.IO

Namespace Advent_of_Code_7
    Class Program

        Public Shared Sub Main(ByVal args As String())
            Dim sum As Integer = 0
            Dim rank As Integer = 1
            Dim hands As List(Of Hand)() = New List(Of Hand)(6) {}

            For i As Integer = 0 To 7 - 1
                hands(i) = New List(Of Hand)()
            Next

            For Each line As String In File.ReadAllLines("C:\Games\7.txt")
                Dim toks As String() = line.Split(" "c)
                Dim bet As Integer = Integer.Parse(toks(1))
                toks(0) = toks(0).Replace("A", "Z").Replace("K", "Y").Replace("Q", "X").Replace("J", "1")
                hands([GetCardType](toks(0))).Add(New Hand() With {
                        .Cards = toks(0),
                        .Bet = bet
                    })
                rank += 1
            Next

            For i As Integer = 0 To 7 - 1
                hands(i).Sort()

                For j As Integer = 0 To hands(i).Count - 1
                    rank = rank - 1
                    sum += rank * hands(i)(j).Bet
                Next
            Next

            Console.WriteLine(sum)
        End Sub

        Private Shared Function [GetCardType](ByVal a As String) As Integer
            Dim counts As Integer() = New Integer(255) {}
            Dim js As Integer = 0

            For i As Integer = 0 To a.Length - 1

                If a(i) <> "1"c Then
                    counts(Asc(a(i))) += 1
                Else
                    js += 1
                End If
            Next

            Dim max As Integer = counts.Max()
            max += js

            If max = 5 Then
                Return 0
            End If

            If max = 4 Then
                Return 1
            End If

            If max = 3 Then
                If a.Contains("1") Then
                    If a.Distinct().Count() = 3 Then
                        Return 2
                    End If
                Else
                    If a.Distinct().Count() = 2 Then
                        Return 2
                    End If
                End If

                Return 3
            End If

            If max = 2 Then
                If a.Contains("1") Then
                    If a.Distinct().Count() = 4 Then
                        Return 4
                    End If
                Else
                    If a.Distinct().Count() = 3 Then
                        Return 4
                    End If
                End If
                Return 5
            End If

            Return 6
        End Function
    End Class

    Class Hand : Implements IComparable

        Public Cards As String
        Public Bet As Integer


        Public Function CompareTo(x As Object) As Integer Implements IComparable.CompareTo
            Dim a As Hand
            Try
                a = CType(x, Hand)
                For i As Integer = 0 To x.Cards.Length - 1

                    If x.Cards(i) <> Cards(i) Then
                        Return x.Cards(i).CompareTo(Cards(i))
                    End If
                Next
            Catch ex As Exception
            End Try
            Return 0
        End Function
    End Class
End Namespace
