OUT = Out.data
IN = Input.data

all: $(OUT)
	cat $<

$(OUT): main.exe $(IN)
	> $@
	echo 'Exercise "Generic List" part B:' >> $@
	echo '\ninput: Irregular table:' >>$@
	cat $(IN) >> $@
	echo '\noutput: Regular table:' >>$@
	mono main.exe < $(IN) >> $@

$(IN): Makefile
	> $@
	echo 129.24 '   '  0.248 '\t   \t' 4.847 >> $@
	echo '  \t    \t ' 88.6 '  \t\t\t     '  33.745 7.78 >> $@
	echo 30.39 99.811 '\t \t ' 6.723 >> $@
	echo '\t' -1.33   96.3 '\t'    2.23 >> $@
	echo '\t' -9.99 	99.99 '\t \t' 9999.99 >> $@

main.exe: main.cs genlist.dll
	mcs -target:exe -out:$@ $< -reference:genlist.dll 

genlist.dll: genlist.cs 
	mcs -target:library -out:genlist.dll genlist.cs

.PHONEY: clean
clean: 
		$(RM) [Oo]ut* *.exe *.dll