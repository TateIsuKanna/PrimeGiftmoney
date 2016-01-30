'Module Module1
'	Dim kind(8) As Integer
'	Dim combination(8) As Integer '現在の枚数の組み合わせ
'	Dim sum As Integer

'	Dim result As Integer





'	Sub Main()
'		kind(0) = 10000
'		kind(1) = 5000
'		kind(2) = 1000
'		kind(3) = 500
'		kind(4) = 100
'		kind(5) = 50
'		kind(6) = 10
'		kind(7) = 5
'		kind(8) = 1

'		For sum = 2 To 50000
'			If IsPrime(sum) Then
'				serach(sum, 0)
'				Console.WriteLine(sum)
'			End If
'		Next
'		Console.WriteLine(result)
'		Stop
'	End Sub


'	Sub serach(value As Integer, money_kind As Integer)
'		If money_kind = 8 Then '1円玉
'            If value <= 19 AndAlso IsPrime(value) Then
'				combination(money_kind) = value '1円玉だから金額そのまま
'				If IsPrime(combination.Sum()) Then
'					For i = 0 To 8
'						'Console.Write(combination(i) & " ")
'					Next
'					result += 1
'					'Console.WriteLine(sum & " " & result)
'				End If
'			End If
'			Exit Sub
'		End If
'		For n = 0 To value \ kind(money_kind)
'			If n <= 19 AndAlso (n = 0 OrElse IsPrime(n)) Then
'				combination(money_kind) = n
'				serach(value - n * kind(money_kind), money_kind + 1)
'			End If
'		Next
'	End Sub
'	Function IsPrime(n As Integer) As Boolean
'		If n = 1 Then
'			Return False
'		End If
'		For divisor = 2 To Math.Sqrt(n)
'			If n Mod divisor = 0 Then
'				Return False
'			End If
'		Next
'		Return True
'	End Function
'End Module
Module Module1
	Dim kind(8) As Integer
	Dim combination(8) As Integer '現在の枚数の組み合わせ
	Dim sum As Integer

	Dim result As Integer

	Dim prime(50000) As Boolean

	Sub Main()
		kind(0) = 10000
		kind(1) = 5000
		kind(2) = 1000
		kind(3) = 500
		kind(4) = 100
		kind(5) = 50
		kind(6) = 10
		kind(7) = 5
		kind(8) = 1

		For n = 0 To 50000
			prime(n) = IsPrime(n)
		Next

		For sum = 2 To 50000
			If prime(sum) Then
				serach(sum, 0)
				Console.WriteLine(sum)
			End If
		Next
		Console.WriteLine(result)
		Stop
	End Sub


	Sub serach(value As Integer, money_kind As Integer)


		If money_kind = 8 Then '1円玉
            If value <= 19 AndAlso prime(value) Then
				combination(money_kind) = value '1円玉だから金額そのまま
				If prime(combination.Sum()) Then
					For i = 0 To 8
						'Console.Write(combination(i) & " ")
					Next
					result += 1
					'Console.WriteLine(sum & " " & result)
				End If
			End If
			Exit Sub
		End If
		For n = 0 To value \ kind(money_kind)
			If money_kind <= 2 Then '紙幣
				If n = 0 OrElse prime(n) Then
					combination(money_kind) = n
					serach(value - n * kind(money_kind), money_kind + 1)
				End If
			Else
				If n <= 19 AndAlso (n = 0 OrElse prime(n)) Then
					combination(money_kind) = n
					serach(value - n * kind(money_kind), money_kind + 1)
				End If
			End If
		Next
	End Sub
	Function IsPrime(n As Integer) As Boolean
		If n = 1 Then
			Return False
		End If
		For divisor = 2 To Math.Sqrt(n)
			If n Mod divisor = 0 Then
				Return False
			End If
		Next
		Return True
	End Function
End Module