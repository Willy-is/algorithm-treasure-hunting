# Algorithm for optimal decision

This project is one of the assessments done at university to improve problem solving skill.

## Scenario

There are Alex and Cindy that found a number of boxes full of coins. Boxes are of different value and now are lined up in a row. </br>
Cindy proposes a fair idea that she and Alex take turns, and each of them chooses either left or right box. She also suggests Alex goes first and he is wondering whether he has more total value than her.

## Solution

It is assumed that both Alex and Cindy pick a box that leads to the best overall value. It means that they will not always choose the higher value (coins) on each of their turns.

### Assumption:

P(i, j) = Optimal strategy for Alex to select either [i] box or [j] box. </br>

There are two cases:

1. Select the left box </br>
   When Alex selects the left box, Cindy has two choices ([i+1] || [j]). She will pick a box that leaves Alex with the minimum value as she is assumed to make an optimal decision.</br>
   Therefore, Alex will have a value of **[i] + Min(P(i+2, j), P(i+1, j-1))**.
   <img width="500" alt="alex-left-choice" src="https://user-images.githubusercontent.com/57608628/148709954-710ff496-e39d-4228-bcbb-af958683d6b1.png">

2. Select the right box </br>
   When Alex chooses the right box, once again, Cindy has two options ([i] || [j-1])and will leave him with the minimum value. </br>
   In this case, Alex will have a value of **[j] + Min(P(i+1, j-1), P(i, j-2))**.
   <img width="500" alt="alex-right-choice" src="https://user-images.githubusercontent.com/57608628/148709957-a2b18a45-e8d3-4e7b-bb9f-43a5ea11c44b.png">

<br> As Alex is always looking for the bigger value, his value would be **Max([i] + Min(P(i+2, j), P(i+1, j-1)), [j] + Min(P(i+1, j-1), P(i, j-2)))** </br>
For example, if there are (6,4,3,5) coins in each box:
P(0, 3) = Max(6 + Min(P(2, 3), P(1, 2)), 5 + Min(P(1, 2), P(0, 1)) = Max(6 + 4, 5 + 4) = 10.

### Base case:

- One Box: if j == i, P(i, j) = [i]
- Two Boxes: if j == i + 1, P(i, j) = Max([i], [j])
