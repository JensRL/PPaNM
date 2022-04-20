import numpy as np
from scipy.integrate import quad


#Define Functions
i = 0
def invsqrtx(x):
    global i
    i+=1
    return 1/np.sqrt(x)

l = 0
def lnsqrtx(x):
    global l
    l+=1
    return np.log(x)/np.sqrt(x)

#Integrate the functions
Res1 = quad(invsqrtx, 0, 1)
Res2 = quad(lnsqrtx, 0, 1)

print('Integral of 1/sqrt(x) =', Res1[0], 'with i =', i, 'calls')
print('Integral of ln(x)/sqrt(x) =', Res2[0], 'with l =', l, 'calls')


