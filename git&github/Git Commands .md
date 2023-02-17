

# Git & Github ultimate command-line guide.

> I have the used  [The Markdown Guide](https://www.markdownguide.org)! to help me in writing this document. 

## Important notes
| command | Description |
| ----------- | ---- |
| `git help` | to show different common commands  |
| ` git <command> -help ` | will give u all the sub commands for it. |
| `git <command> --help` | will open the documentation file for the command in browser.  |


```
The help section is a super helpful resource when needed
```

---
### Linux commands

| command | Description |
| ----------- | ---- |
| `ls -a  ` | list of files + *hidden files* |
| `cd .. ` | cd takes you into a path , the dots gets you back in reverse|
| `cat <file name> ` | reads a file |
| `touch <filename.txt> ` | creates a file |
| ` mkdir <foldername> ` | creates a folder |
| ` ctrl + u ` | clears what you just wrote in the command line |

---

### Vim commands

| command | Description |
| ----------- | ---- |
| `vim <filename.txt>` | opens the file in vim |
| `i` | allows you to insert text|
| `ESC` | exits the writing mode and enter command mode |
| `:w` | saves what your wrote |
| `:q` | quit|
| `:wq` | save(write) and quit |
| `:q!` | quit without save |


---


### Common Git workflow (updated regularly)

| command | Description |
| ----------- | ---- |
| `git init  ` | create a repo |
| ` git add . ` | git add . => will add all the new files and the files that have changs to the staging area |
| `git commit -am "your commit messge"` | will open the documentation file for the command in browser. **Note that**: it will not add new files as they have not been tracked before in that case use  `git add .` then  `git commit -m "your msg"` |
| `git commit -v  ` *needs more understanding*| this gives the diff between your previous and new document before commiting to it, the is also a config command you need to make which is `git config --global commit.verbose true ` [source](https://stackoverflow.com/questions/5875275/git-commit-v-by-default) |
| `git status  ` | gives info about all the staged/unstaged files |
| `git log --oneline ` | branch commits in a short line. <br> **Note:** Press `q` to exit the logs window.  |
| `git log --oneline <master branch>..<target branch>  ` | This will show the commits created by the target branch only, that was created before from the specfic branch (master branch)  |
| `git diff <branch1>..<branch2> ` | guves the difference between the 2 branches, helpful before doing commits  |

#### General Notes

1. You can combine commands using `&&` 
 ex: `git add . && git commit -am "hi there"`


---

### Branches 
| command | Description |
| ----------- | ---- |
| `git branch ` |  gives a list of created branches, adding things to it gives it more functionality.  **-d delete -c copy -m move/rename** , <br><br> you have to be on the branch you want to rename and just use `git branch -m <new name>` |
| `git branch <branch name> ` |  creates a branch |
| `git switch <branch name> ` |  switch to a new branch|
| `git checkout <branch name>  ` | is the older version from `git switch` but has more functionality.. this lead to it not being used now.  |
| `git switch -c <branch name>  ` | create a new branch *AND* switch to it |

#### Branch Notes

1. Make sure you add changes and commit before switching to a new branch, other wise you will face a strange behaviour. 
2. `git branch -D` (upperCase D) will **froce delete**
3.  `.git/HEAD` stores references for the latest commits for our branches. 
4. Depending on the branch you are currently on, the files you see in the file browers will be different.

---


### Merging   ( locally )
| command | Description |
| ----------- | ---- |
| `git merge <branch name> ` |  The branch name is the one we import data from to the current branch we are standing on. |
| `git merge --abort ` |  stops the merge and tries to re-construct the state before starting the merge. |


#### Merging Notes ( locally )

1. Merging DOES NOT delete any of the branches, they just become in sync 
for that specific moment in time. 

2. **Case 1:** : fast-forward merge.....
We merge into the active branch, the one that has the 
HEAD pointer on it.

Tha'ts why we have to first 
1. `git switch master`  we switched to the branch we want to merge into 
2. `git merge bugfix` the branch we want to merge intoo our main branch 
3. this will move the `master branch` reference to where `bug fix ` reference is.

```
	This is called fast-forward merge, 
	where is the master is only behind on couple of commits,
	but in the real world.. it's more tricky 
```

3. **Case 2:** : The master have commits that you don't have, which means he might have edited a line you are using. 
*This will result in conflict*
Head >> is our current branch
bug-fix >> is the other branch that has the in-coming changes.

*Note* : 

	1. you have to type `code .` after the conflict msg appear, So that the file gets opened in VS Code,
	2.then your press `resolve in conflict manger`
	3. left panel is the incoming, right panel is the current
	and the bottom is the combination and how the actual file will look like.
	4. after finishing your edit press `complete merge` on the bottom right
	5. You will promoted to enter a new commit msg for the merge operation, it will be usually like `merged <branch name> into <active branch>




4.  >" You can't merge into a branch in the general case without having it checked out. There's a good reason for this, however. You need the proper working tree in order to denote and resolve merge conflicts."
[Source](https://stackoverflow.com/a/6778792/19319830)


---


### Stashing 

It allows you to switch to another branch without commiting to your current changes, This keeps the commiting history clean.
| command | Description |
| ----------- | ---- |
| `git stash `/ `git stash save` | it saves your changes, if you use `git status` afterward you will see that there is nothing to commit. |
| `git stash pop ` | retrive the latest save you have made. |
| `git stash apply ` | same as pop, but you only pop a copy from the changs, you will still have the changes stashed and you can use them on another branch. |
| `git stash list ` | List the number of stashed changes,it gives us the latest commit we had when we created that stash, helpful when multi-stashing. `not commonly used` |
| `git stash apply stash@{i} ` | Where `i` is the stash number you got from `git stash list` |
| `git stash drop stash@{i} `/ `git stash clear` | removing a specific stash or clearing the whole stash list. |



#### Stashing Notes

1. if you are on a branch and did not commit it's changes, then switched to another branch, the changes will either 
	1. come with you to the new branch and you would need to go back 
	to the old branch to commit them and get them away
	2. you would get a warning that you will lose your changes 
		>*This gets solved by using stashing. *

2. What about Multiple stashes ?! 
	 starting from `git stash list` in the table.


---

### undo your changes 


| command | Description |
| ----------- | ---- |
| `git checkout d8194d6` | go to a specfic commit using it's hash code that you get from `git log --oneline`.<br> *Warning* using this command gives you the `Detached head` state. <br> To go back to normal state, use `git switch <branch name> `|
| `git checkout HEAD~1` | go back one commit. <br> We are referencing commits relative to our current HEAD positon.<br>Ex: repeating the command will keep moving you backward in commits |
| `git checkout HEAD cat.txt dog.txt`/ `git checkout -- cat.txt dog.txt` | Will undo what you changed in the file and revert to your last commit.. basically it's like `ctrl+z`, We didn't modify the commits itself. |
| `git restore dog.txt` | New command that takes some of the things that `git checkout` do.<br> will also revert to the last commit |
| `git restore --staged dog.txt` | Will un-stage the specificed file, to not include it in the commit.<br>Even when you type `git status` you will notice that this command is recommended by Git|
| `git reset <commit-hash>` *Important* | Will reset the repo to the specified commit.<br> <br>But this only removes the commits,the file changes themselves are still there in `git status`. <br><br> This is useful if `you made changes to the wrong branch, this will remove the commits but keeps the changes so you can stash them to another branch or create a new branch with them. |
| `git reset -- hard <commit-hash>` *Be careful* | This will remove both,<br> **commits and changes**, <br>in one command. |
| `git revert <commit-hash>` | creates a new commit that gets you to the same stage of your specified <commit-hash> <br> This is safer than removing things from the commit history which is done by `git reset` <br><br> `Better for collabration` as some people might have the same commits I removed using `git reset` |




#### undo your changes Notes

1. normally HEAD points at a branch reference, which is the name of the branch that is always on the last commit.
But using `git checkout <commit hash>` gets HEAD to point to a `specific commit`.

> What is the benfit of doing that? 

We can use `git switch -c <new branch name>` while in detached head mode. and this will create a new branch that have only the commits that the detached state can see. <br>
Then we can use that for testing something.


---

### Github basic commands

It allows you to switch to another branch without commiting to your current changes, This keeps the commiting history clean.
| command | Description |
| ----------- | ---- |
| `git clone <url>` | Use the command inside the local folder you want to clone the files into. <br>it doesn't matter if the repo is on `github` or a `server`, the command will clone it for you.<br> The `url` that github gives you, is the same url that is in the browser when you are in the repo.|
| `git remote -v` | gives you the remote `repo alias` and it's `url` |
| `git remote add <name> <url>` | This creates a remote connection, the name is usually used as `origin`, but we can use anything else. |
| `git remote rename <old> <new>` | rename the remote alias |
| `git remote remove <name> ` | removes the remote connection, as in projects we will usually have more than one.  |
| `git push <remote> <branch> ` | pushes the branch you specify... to the remote you specify.<br> If there is a branch in the remote repo with the same name as our local repo, then they get merged. <br> <br> Note: We might need to change our local `master` branch to `main`, as that's what is being used by github now. <br> This is done by using the following command: <br><br> you have to be on the branch you want to rename and just use `git branch -m <new name>` |
| `git push <remote> <local-branch> : <remote-branch> ` | this will push our local branch into a remote branch instead of creating a remote branch with the same name as our local branch name. |
| `git push -u <remote> <branch name> ` | The `u` will save which branch you choose to push to which branch, this will set an automatic-upstream and give the following msg: <br> <br> `branch 'sherazeCat' set up to track 'egyptorigin/cat'.` as an example <b> <b> This means if we just use `git push ` the next time, Git will know which branches should recieve our changes.  |





#### Github basic commands Notes

1. SSH key (Secure shell) allows you to be authenticated without entering your ID/PW every time. [github doc on SSH](https://docs.github.com/en/authentication/connecting-to-github-with-ssh)

2.How do we get our code on github? 

	1.Method-1- uploading your local repo

		1. Create a new repo on github
		2. Connect your local repo to that github repo (using add remote)
		3. Push up your changes to Github.
		
	2.Method-2- Fresh start

		1. Create a new repo on github.
		2. Clone it down to your machine.
		3. Do some work locally.
		4. Push up your changes to Github.







| `git log  ` | |
| `git log  ` | |
| `git log  ` | |
| `git log  ` | |
| `git log  ` | |
| `git log  ` | |
| `git log  ` | |
| `git log  ` | |
| `git log  ` | |
| `git log  ` | |
| `git log  ` | |
| `git log  ` | |
| `git log  ` | |
| `git log  ` | |
| `git log  ` | |
| `git log  ` | |




