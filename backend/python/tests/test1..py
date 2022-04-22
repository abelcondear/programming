# find bug 2 lines 
def solution(A, K):
    n = len(A) #correct
    for i in range(n - 1): #correct
        if (A[i] + 1 < A[i + 1]):
            return False
            
    if (A[0] != 1 and A[n - 1] != K): #this line is correct
        return False
    else:
        return True
        
range = n = 5 = [1, 1, 2, 3, 3]         

print(solution([1, 1, 2, 3, 3], 3)) #True

print(solution([1, 1, 3], 2)) #False